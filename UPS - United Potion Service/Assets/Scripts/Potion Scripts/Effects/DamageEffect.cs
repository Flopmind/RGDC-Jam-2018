using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : PotionEffect
{

    // damage dealt by the effect to the health of its targets
    private int damage;
    public int Damage { get { return damage; } set { damage = value; } }
    
    // constructor
    public DamageEffect(int dmg)
    {
        damage = dmg;
    }

    // implementation of damage effect
    public override void ApplyEffect(VehicleScript entity)
    {
        entity.GetComponent<HealthScript>().TakeDamage(damage);
    }
}
