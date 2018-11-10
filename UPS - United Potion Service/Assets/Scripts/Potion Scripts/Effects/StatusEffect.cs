using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : PotionEffect {

	public StatusEffect(float timer, string name)
    {
        effectTimer = timer;
        name = effectName;
    }

    public override void ApplyEffect(VehicleScript entity)
    {
        
    }
}
