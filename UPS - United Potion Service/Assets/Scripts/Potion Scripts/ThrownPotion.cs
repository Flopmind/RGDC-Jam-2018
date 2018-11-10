using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrownPotion : Potion {
    
    protected Vector3 activationLocation;
    protected GameObject[] enemies;
    protected bool locationSet = false;

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
        if (locationSet && Vector3.SqrMagnitude(transform.position - activationLocation) < .01)
        {
            TriggerEffect();
        }
    }

    public virtual void AffectEnemy(EnemyScript enemy)
    {
        if (myEffect)
        {
            enemy.AddEffect(myEffect);
        }
    }
}
