using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthScript))]
public abstract class EnemyScript : VehicleScript {

    [SerializeField]
    protected float aggroRange;
    [SerializeField]
    protected int attackDamage;

    protected GameObject player;
    protected GameObject target = null;
    protected List<PotionEffect> doneEffects;

    public int Damage
    {
        get { return attackDamage; }
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
        foreach (PotionEffect effect in activeEffects)
        {
            if (effect.Done)
            {
                doneEffects.Add(effect);
            }
        }

        for (int i = 0; i < doneEffects.Count; i++)
        {
            activeEffects.Remove(doneEffects[i]);
        }
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
