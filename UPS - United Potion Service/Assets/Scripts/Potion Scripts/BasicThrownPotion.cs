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
        Instantiate(Resources.Load<GameObject>("Explosion"), activationLocation, Quaternion.identity);
        foreach (GameObject enemy in enemies)
        {
            AffectEnemy(enemy.GetComponent<EnemyScript>());
        }
        Destroy(gameObject);
    }

    protected override void AffectEnemy(EnemyScript enemy)
    {
        base.AffectEnemy(enemy);
        if ((transform.position - enemy.transform.position).magnitude <= damageRadius)
        {
            enemy.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }
}
