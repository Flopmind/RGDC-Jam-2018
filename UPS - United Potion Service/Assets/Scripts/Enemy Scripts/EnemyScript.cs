using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthScript))]
public abstract class EnemyScript : VehicleScript {

    [SerializeField]
    protected float aggroRange;
    [SerializeField]
    protected int attackDamage;
    [SerializeField]
    protected int cost;

    protected GameObject player;
    protected GameObject target = null;

    protected Animator anim;

    public int Damage
    {
        get { return attackDamage; }
    }

    public int Cost
    {
        get { return cost; }
    }
    
	protected void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
	}

    protected void EnemyUpdate()
    {
        if (player)
        {
            doneEffects = new List<PotionEffect>();
            TargetPlayer();
            VehicleUpdate();
            Animate(GetComponent<Rigidbody2D>().velocity);
        }
    }

    protected void TargetPlayer()
    {
        if (player && (transform.position - player.transform.position).magnitude <= aggroRange)
        {
            target = player;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthScript otherHealth = other.gameObject.GetComponent<HealthScript>();
            if (otherHealth != null)
            {
                otherHealth.TakeDamage(attackDamage);
            }
        }
    }

    // Figures out variables to plug into the animator system
    protected void Animate(Vector3 motion)
    {
        if (!anim) return; // exit if animator not established

        // is the unit moving?
        anim.SetBool("Moving", !(motion.x == 0.0f && motion.y == 0.0f));

        // information about direction of movement
        anim.SetFloat("Horizontal", motion.x);
        anim.SetFloat("Vertical", motion.y);

        anim.SetFloat("Ratio", (motion.y / motion.x));
    }
}
