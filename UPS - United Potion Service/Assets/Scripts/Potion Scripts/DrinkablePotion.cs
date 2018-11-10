using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkablePotion : Potion {

    [SerializeField]
    public int uses = 1;

    protected GameObject player;
    protected bool consumed = false;

    private void Start()
    {
        PotionStart();
    }

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

    protected override void TriggerEffect()
    {
        if (myEffect != null)
        {
            player.GetComponent<VehicleScript>().AddEffect(myEffect);
        }
    }
}
