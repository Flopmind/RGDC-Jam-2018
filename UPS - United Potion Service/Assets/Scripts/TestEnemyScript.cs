using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : EnemyScript {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	void Update ()
    {
        ApplyForces();
	}

    protected override Vector3 CalculateForces()
    {
        if (target)
        {
            //print("target");
            return Seek(target);
        }
        //print("no target");
        return Vector3.zero;
    }
}
