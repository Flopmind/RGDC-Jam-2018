using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : VehicleScript {

    public float moveMag;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        ApplyForces();
    }

    protected override Vector3 CalculateForces()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            return (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized) * moveMag;
        }
        return Vector3.zero;
    }
}
