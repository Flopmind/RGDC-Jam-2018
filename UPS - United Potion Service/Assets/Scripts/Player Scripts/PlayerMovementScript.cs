using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : VehicleScript {

    [SerializeField]
    protected float moveMag;
    [SerializeField]
    protected float speedMoveMag;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        VehicleUpdate();
    }

    protected override Vector3 CalculateForces()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (ContainsEffect("Speed"))
            {
                return (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized) * speedMoveMag;
            }
            return (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized) * moveMag;
        }
        return Vector3.zero;
    }
}
