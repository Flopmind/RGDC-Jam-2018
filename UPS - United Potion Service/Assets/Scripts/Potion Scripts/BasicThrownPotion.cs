using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicThrownPotion : ThrownPotion {

    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float damageRadius;

	void Start ()
    {
        PotionStart();
	}
	
	void Update ()
    {
        PotionUpdate();
    }

    protected override void TriggerEffect()
    {
        Explosion ex = Instantiate(Resources.Load<GameObject>("Explosion"), activationLocation, Quaternion.identity).GetComponent<Explosion>();
        ex.radius = damageRadius;
        ex.effect = new DamageEffect(damage);
        Destroy(gameObject);
    }
}
