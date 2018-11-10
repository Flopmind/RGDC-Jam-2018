using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionEffect
{

    [SerializeField]
    protected float effectTimer;
    [SerializeField]
    protected string effectName;

    protected bool done = false;

    public abstract void ApplyEffect(VehicleScript entity);

    public float Timer
    {
        get { return effectTimer; }
        set { effectTimer = value; }
    }

    public bool Done
    {
        get { return done; }
    }

    public string Effect
    {
        get { return effectName; }
    }

    public void EffectUpdate()
    {
        if (!done)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
            done = true;
        }
    }

}
