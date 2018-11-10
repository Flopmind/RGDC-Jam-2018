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
        transform.localRotation *= Quaternion.AngleAxis(-1080 * Time.deltaTime, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEffect();
    }
    protected override void TriggerEffect()
    {
        print("Meh");
        Explosion ex = Instantiate(Resources.Load<GameObject>("Explosion"), transform.position, Quaternion.identity).GetComponent<Explosion>();
        ex.Radius = damageRadius;
        ex.effect = new DamageEffect(damage);
        Destroy(gameObject);
    }
}
