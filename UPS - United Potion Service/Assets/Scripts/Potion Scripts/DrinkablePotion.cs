using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkablePotion : Potion {

    [SerializeField]
    protected int uses = 1;
    [SerializeField]
    protected float timer;
    [SerializeField]
    protected string effectName;

    protected GameObject player;
    protected bool consumed = false;

    private void Start()
    {
        
    }

    protected override void PotionStart()
    {
        base.PotionStart();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Initialize()
    {
        PotionStart();
        if (timer <= 0 || effectName == default(string))
        {
            throw new System.Exception("Set timer and/or name on this potions");
        }
        myEffect = new StatusEffect(timer, effectName);
    }

    public void Drink()
    {
        if (!consumed)
        {
            TriggerEffect();
            --uses;
            consumed = (uses <= 0);
        }
    }

    protected override void TriggerEffect()
    {
        if (myEffect != null)
        {
            player.GetComponent<VehicleScript>().AddEffect(myEffect);
        }
    }
}
