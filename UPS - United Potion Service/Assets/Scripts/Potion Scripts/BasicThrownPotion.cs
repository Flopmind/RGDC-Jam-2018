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
        transform.localRotation *= Quaternion.AngleAxis(-520 * Time.deltaTime, Vector3.forward);
    }

    protected override void TriggerEffect()
    {
        Explosion ex = Instantiate(Resources.Load<GameObject>("Explosion"), activationLocation, Quaternion.identity).GetComponent<Explosion>();
        ex.Radius = damageRadius;
        ex.effect = new DamageEffect(damage);
        Destroy(gameObject);
    }
}
