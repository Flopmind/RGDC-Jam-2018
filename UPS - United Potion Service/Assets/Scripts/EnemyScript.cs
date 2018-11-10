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

    protected override void ApplyForces()
    {
        TargetPlayer();
        base.ApplyForces();
    }
}
