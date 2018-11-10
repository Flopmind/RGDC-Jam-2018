using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleScript : MonoBehaviour {

    public float steerMag;
    public float pursuitMag;
    public float evadeMag;
    
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

    protected Vector3 Flee(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = (transform.position - targetPosition).normalized;

        return steerMag * (desiredVelocity - velocity).normalized;
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

    protected void ApplyForces()
    {
        Vector3 netForce = CalculateForces();

        velocity += netForce;

        //Add in friction

        transform.position = transform.position + (velocity * Time.deltaTime);
    }
}
