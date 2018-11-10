using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : EnemyScript {

	// Use this for initialization
	void Start ()
    {
        Initialize();
	}
	
	void Update ()
    {
        EnemyUpdate();
	}

    protected override Vector3 CalculateForces()
    {
        if (target)
        {
            return Seek(target);
        }
        return Vector3.zero;
    }
}
