using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrownPotion : Potion {

    protected Vector3 activationLocation;
    protected GameObject[] enemies;
    protected bool locationSet = false;
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

    //public void SetEnemies(GameObject[] myEnemies)
    //{
    //    enemies = myEnemies;
    //}

    public void SetDistances(float max, float dist)
    {
        distance = dist;
        if (distance > max)
        {
            distance = dist;
        }
    }
    
    protected override void PotionStart()
    {
        base.PotionStart();
        //StartCoroutine(WaitUntilEffect());
    }
    
    protected virtual void PotionUpdate()
    {
        if (locationSet && (Vector3.SqrMagnitude(transform.position - activationLocation) < .01) || (transform.position - activationLocation).magnitude >= distance)
        {
            TriggerEffect();
        }
    }
}
