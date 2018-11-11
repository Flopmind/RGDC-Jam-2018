using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class VehicleScript : MonoBehaviour {


    [SerializeField]
    protected float moveMag;
    [SerializeField]
    protected float speedMag;
    [SerializeField]
    protected float slowMag;
    [SerializeField]
    protected float steerMag;
    [SerializeField]
    protected float pursuitMag;
    [SerializeField]
    protected float evadeMag;
    [SerializeField]
    protected float knockCount;

    protected Vector3 velocity = Vector3.zero;
    protected Vector3 knock = Vector3.zero;
    protected float knockTimer = 0;
    protected List<PotionEffect> activeEffects = new List<PotionEffect>();
    protected List<GameObject> potions;
    protected List<PotionEffect> doneEffects;

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public void AddEffect(PotionEffect effect)
    {
        activeEffects.Add(effect);
    }

    public bool ContainsEffect(PotionEffect effect)
    {
        return ContainsEffect(effect.Effect);
    }

    public bool ContainsEffect(string effectName)
    {
        foreach (PotionEffect effect in activeEffects)
        {
            if (effect.Effect == effectName)
            {
                return true;
            }
        }
        //print(false);
        return false;
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
        Vector3 velo = Vector3.zero;
        velo = CalculateForces().normalized * moveMag;

        if (ContainsEffect("Speed") && !ContainsEffect("Slow"))
        {
            velo = velo * speedMag;
        }
        else if (ContainsEffect("Slow"))
        {
            velo = velo * slowMag;
        }
        if (knock != Vector3.zero)
        {
            velo = knock;
        }
        GetComponent<Rigidbody2D>().velocity = velo;
    }

    protected void EffectUpdates()
    {
        doneEffects = new List<PotionEffect>();
        foreach (PotionEffect effect in activeEffects)
        {
            effect.EffectUpdate();
            if (effect.Done)
            {
                doneEffects.Add(effect);
            }
        }

        for (int i = 0; i < doneEffects.Count; i++)
        {
            activeEffects.Remove(doneEffects[i]);
        }
    }

    public virtual void VehicleUpdate()
    {
        EffectUpdates();
        ApplyForces();
    }
}
