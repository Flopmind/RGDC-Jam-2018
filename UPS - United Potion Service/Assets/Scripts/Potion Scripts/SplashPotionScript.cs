using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPotionScript : ThrownPotion
{

    [SerializeField]
    protected float timer;
    [SerializeField]
    protected string effectName;
    [SerializeField]
    protected float effectRadius;

    void Start()
    {
        PotionStart();
        if (timer <= 0 || effectName == default(string))
        {
            throw new System.Exception("Set timer and/or name on this potions");
        }
        myEffect = new StatusEffect(timer, effectName);
    }

    void Update()
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
        Explosion ex = Instantiate(Resources.Load<GameObject>("Goosplosion"), transform.position, Quaternion.identity).GetComponent<Explosion>();
        ex.Radius = effectRadius;
        ex.effect = new StatusEffect(timer, effectName);
        Destroy(gameObject);
    }
}
