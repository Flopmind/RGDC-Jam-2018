using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrownPotion : Potion {
    
    protected Vector3 activationLocation;
    protected GameObject[] enemies;

    public Vector3 ActivationLocation
    {
        get
        {
            return activationLocation;
        }
        set
        {
            activationLocation = value;
        }
    }

    public void SetEnemies(GameObject[] myEnemies)
    {
        enemies = myEnemies;
    }

    protected override void PotionStart()
    {
        base.PotionStart();
        //StartCoroutine(WaitUntilEffect());
    }
    
    protected virtual void PotionUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position - activationLocation) < .01)
        {
            TriggerEffect();
        }
    }
}
