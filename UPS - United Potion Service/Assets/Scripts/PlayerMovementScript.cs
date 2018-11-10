﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : VehicleScript {

    public float moveMag;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ApplyForces();
    }

    protected override Vector3 CalculateForces()
    {
        return (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized) * moveMag;
    }
}