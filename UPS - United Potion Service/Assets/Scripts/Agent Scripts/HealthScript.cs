using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int currentHealth;

    private UnityEngine.UI.Image displayHP;

    public int Health
    {
        get { return currentHealth; }
        set
        {
            if (value < 0)
            {
                if (gameObject.CompareTag("Player"))
                {
                    ScoreTracker.victory = false;
                }
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
        displayHP = GameObject.Find("CurrentHealth").GetComponent<UnityEngine.UI.Image>();
        if (gameObject.name == "protoPlayer")
        {
            print(displayHP);
        }
    }

    private void Update()
    {
        if (displayHP)
        {
            displayHP.fillAmount = Mathf.Clamp((float)currentHealth / (float)maxHealth, 0, 1);
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
