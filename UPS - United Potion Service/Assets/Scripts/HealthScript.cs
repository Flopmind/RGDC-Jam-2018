using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    public int Health
    {
        get { return currentHealth; }
        set
        {
            if (value < 0)
            {
                currentHealth = 0;
            }
            else if (value > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth = value;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
    }
}
