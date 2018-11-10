using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DrinkablePotion : Potion {

    [SerializeField]
    public int uses = 1;

    protected GameObject player;
    protected bool consumed = false;

    protected override void PotionStart()
    {
        base.PotionStart();
        player = GameObject.FindGameObjectWithTag("Player");
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
}
