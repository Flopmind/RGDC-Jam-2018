using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrownPotion : Potion 
{

    protected Vector3 activationLocation;
    protected Vector3 myOrigin;
    protected GameObject[] enemies;
    protected bool locationSet = false;
    protected float distanceTravelled = 0;
    protected float maxDist = 5;
    protected float distance = 0;

    public Vector3 ActivationLocation
    {
        get
        {
            return activationLocation;
        }
        set
        {
            activationLocation = value;
            locationSet = true;
        }
    }

    public void SetDistances(Vector3 origin, float max, float dist)
    {
        myOrigin = origin;
        maxDist = max;
        distance = dist;
    }
    
    protected override void PotionStart()
    {
        base.PotionStart();
        //StartCoroutine(WaitUntilEffect());
    }
    
    protected virtual void PotionUpdate()
    {
        distanceTravelled = (transform.position - myOrigin).magnitude;
        if (locationSet && 
            //Is close to desired location
            ((Vector3.SqrMagnitude(transform.position - activationLocation) < .01)
<<<<<<< HEAD
<<<<<<< HEAD
            // current position, desired position, 
            || (transform.position - activationLocation).magnitude >= distance
=======
            //
            //|| (transform.position - activationLocation).magnitude >= distance
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
=======
            //
            //|| (transform.position - activationLocation).magnitude >= distance
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
            //Has gone too far
            || distanceTravelled >= maxDist))
        {
            TriggerEffect();
        }
    }
}
