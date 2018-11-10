﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class VehicleScript : MonoBehaviour {

    [SerializeField]
    protected float steerMag;
    [SerializeField]
    protected float pursuitMag;
    [SerializeField]
    protected float evadeMag;
    
    [SerializeField]
    protected Vector3 velocity = Vector3.zero;

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    protected Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = (targetPosition - transform.position).normalized;

        return steerMag * (desiredVelocity - velocity).normalized;
    }

    protected Vector3 Seek(GameObject gameObj)
    {
        return Seek(gameObj.transform.position);
    }

    protected Vector3 Flee(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = (transform.position - targetPosition).normalized;

        return steerMag * (desiredVelocity - velocity).normalized;
    }

    protected Vector3 Flee(GameObject gameObj)
    {
        return Flee(gameObj.transform.position);
    }

    protected Vector3 Pursue(VehicleScript targetVehicle)
    {
        return Seek(targetVehicle.transform.position + (pursuitMag * targetVehicle.Velocity));
    }

    protected Vector3 Evade(VehicleScript targetVehicle)
    {
        return Flee(targetVehicle.transform.position + (evadeMag * targetVehicle.Velocity));
    }

    // Calculates and returns the netForce, which should be set to zero at the beginning, based on the other methods in the vehicle class and the needs of the specific vehicle.
    protected abstract Vector3 CalculateForces();

    protected virtual void ApplyForces()
    {
        //Vector3 netForce = CalculateForces();

        //velocity += netForce;

        ////Add in friction


        ////Caps speed
        //if (velocity.magnitude > speedLimit)
        //{
        //    velocity = velocity.normalized * speedLimit;
        //}

        //transform.position = transform.position + (velocity * Time.deltaTime);

        GetComponent<Rigidbody2D>().velocity = CalculateForces();
    }
}
