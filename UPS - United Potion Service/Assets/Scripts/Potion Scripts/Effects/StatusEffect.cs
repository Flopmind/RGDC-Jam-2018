using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : PotionEffect {

	public StatusEffect(float timer, string name)
    {
        effectTimer = timer;
        effectName = name;
    }

    public override void ApplyEffect(VehicleScript entity)
    {
        Debug.Log("Applied");
        entity.AddEffect(this);
    }
}
