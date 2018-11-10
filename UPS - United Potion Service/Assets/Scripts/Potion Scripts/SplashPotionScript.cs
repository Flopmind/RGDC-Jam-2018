using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPotionScript : ThrownPotion
{

    [SerializeField]
    protected float timer;
    [SerializeField]
    protected string effectName;

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
    }

    protected override void TriggerEffect()
    {
        throw new System.NotImplementedException();
    }
}
