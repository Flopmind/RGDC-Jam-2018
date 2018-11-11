﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    [SerializeField]
    private float potionThrowSpeed = 1;
    [SerializeField]
    private float throwInterval = 2;
    [SerializeField]
    protected float maxThrowRange = 6;
    [SerializeField]
    private List<GameObject> myPotions;
    [SerializeField]
    private List<int> potionsCounts;

    private GameObject[] enemies;
    private int index;
    private float throwTimer = 0;
    PlayerInventory inv;
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        index = 0;
        inv = GetComponent<PlayerInventory>();
    }

    // checks for input, instantiates potion and makes potion move
    void Update()
    {
        if (throwTimer <= 0)
        {
            GameObject potionToInstantiate = null;
            if (Input.GetMouseButtonDown(0) && myPotions.Count > 0)
            {
                potionToInstantiate = inv.RetrieveItem((PlayerInventory.PotionType)index);
                if (potionToInstantiate != null)
                {
                    Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                    float distanceTravel = vecToMouse.magnitude;
                    vecToMouse.Normalize();
                    GameObject potionInstance = Instantiate(potionToInstantiate, transform.position + vecToMouse, Quaternion.identity);
                    if (potionInstance.GetComponent<ThrownPotion>())
                    {
                        potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
                        potionInstance.GetComponent<ThrownPotion>().SetDistances(transform.position, maxThrowRange, distanceTravel);
                        potionInstance.transform.up = vecToMouse;
                        potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
                        throwTimer = throwInterval;
                    }
                    else if (potionInstance.GetComponent<DrinkablePotion>())
                    {
                        potionInstance.GetComponent<DrinkablePotion>().Initialize();
                        potionInstance.GetComponent<DrinkablePotion>().Drink();
                        Destroy(potionInstance);
                    }
                    throwTimer = throwInterval;
                }
            }
        }
        else
        {
            throwTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            --index;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ++index;
            print(index);
        }
        if (index > myPotions.Count)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = myPotions.Count - 1;
        }
    }

    public int GetScore()
    {
        int score = 0;
        for (int i = 0; i < myPotions.Count; i++)
        {
            score += myPotions[i].GetComponent<Potion>().Score * potionsCounts[i];
        }
        return score;
    }
    
    public Sprite GetCurrentSprite()
    {
        return myPotions[index].GetComponent<SpriteRenderer>().sprite;
    }

    public GameObject CurrentPotion
    {
        get { return myPotions[index]; }
    }
}
