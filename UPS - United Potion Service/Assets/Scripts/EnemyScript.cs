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
    protected List<PotionEffect> activeEffects = new List<PotionEffect>();

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
        TargetPlayer();
        ApplyForces();
    }

    protected void TargetPlayer()
    {
        if (player)
        {
            print((transform.position - player.transform.position).magnitude + ", " + aggroRange);
        }
        if (player && (transform.position - player.transform.position).magnitude <= aggroRange)
        {
            target = player;
        }
    }
}
