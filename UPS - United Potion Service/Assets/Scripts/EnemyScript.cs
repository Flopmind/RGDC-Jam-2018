using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthScript))]
public abstract class EnemyScript : VehicleScript {

    [SerializeField]
    protected float aggroRange;

    protected GameObject player;
    protected GameObject target = null;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
            throw new System.ArgumentNullException("Player not found in EnemyScript");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected void TargetPlayer()
    {
        if (player && (transform.position - player.transform.position).magnitude <= aggroRange)
        {
            target = player;
        }
    }
}
