using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : DrinkablePotion {

    [SerializeField]
    protected int healthGained;

	void Start()
    {
        PotionStart();
	}

    protected override void TriggerEffect()
    {
        player.GetComponent<HealthScript>().Heal(healthGained);
    }
}
