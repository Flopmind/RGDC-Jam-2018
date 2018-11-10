using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 1;
    private int currentHealth;

    public int Health
    {
        get { return currentHealth; }
        set
        {
            if (value < 0)
            {
                // currentHealth = 0;
                Destroy(gameObject);
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

    private void Start()
    {
        Health = maxHealth;
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Health = Health - damage;
        }
    }

    public void Heal(int healing)
    {
        if (healing > 0)
        {
            Health += healing;
        }
    }
}
