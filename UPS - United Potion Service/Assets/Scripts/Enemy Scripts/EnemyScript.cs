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
        if (!player)
            throw new System.ArgumentNullException("Player not found in EnemyScript");
	}

    protected void EnemyUpdate()
    {
        doneEffects = new List<PotionEffect>();
        TargetPlayer();
        VehicleUpdate();
    }

    protected void TargetPlayer()
    {
        if (player && (transform.position - player.transform.position).magnitude <= aggroRange)
        {
            target = player;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
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
}
