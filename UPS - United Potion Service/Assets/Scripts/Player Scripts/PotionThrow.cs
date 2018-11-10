using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    [SerializeField]
    private GameObject potionPrefab;
    [SerializeField]
    private int basePotionCount = 0;
    [SerializeField]
    private float potionThrowSpeed = 1;
    [SerializeField]
    private float throwInterval;
    [SerializeField]
    protected float maxThrowRange = 6;
    [SerializeField]
    private List<GameObject> myPotions;
    [SerializeField]
    private List<int> potionCounts;

    private GameObject[] enemies;
    private int index;
    PlayerInventory inv;
    private float throwTimer = 0;

    private void Start()
    {
        if (myPotions.Count != potionCounts.Count || basePotionCount == 0)
        {
            throw new System.NullReferenceException("Populate potions and potion counts properly");
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        index = 0;
        inv = GetComponent<PlayerInventory>();
    }

    // checks for input, instantiates potion and makes potion move
    void Update () 
	{
        GameObject potionToInstantiate = null;
		if (Input.GetMouseButtonDown(0))
		{
            potionToInstantiate = inv.RetrieveItem(PlayerInventory.PotionType.Explosion);
            if (potionToInstantiate != null)
            {
                Vector3 vecToMouse = (MousePos.MousePosition - transform.position).normalized; 
                GameObject potionInstance = Instantiate(potionToInstantiate, transform.position + vecToMouse, Quaternion.identity);
                potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
                //potionInstance.GetComponent<ThrownPotion>().SetEnemies(enemies);
                potionInstance.transform.up = vecToMouse;
                potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
            }
		}
        else if (Input.GetMouseButtonDown(1) && myPotions.Count > 0)
        if (throwTimer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                float distanceTravel = vecToMouse.magnitude;
                vecToMouse.Normalize();
                GameObject potionInstance = Instantiate(potionPrefab, transform.position + vecToMouse, Quaternion.identity);
                potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
                potionInstance.GetComponent<ThrownPotion>().SetDistances(transform.position, maxThrowRange, distanceTravel);
                //potionInstance.GetComponent<ThrownPotion>().SetEnemies(enemies);
                potionInstance.transform.up = vecToMouse;
                potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
                throwTimer = throwInterval;
            }
            else if (Input.GetMouseButtonDown(1) && myPotions.Count > 0)
            {
                Vector3 vecToMouse = (MousePos.MousePosition - transform.position).normalized;
                GameObject potionInstance = Instantiate(myPotions[index], transform.position + vecToMouse, Quaternion.identity);
                if (potionInstance.GetComponent<ThrownPotion>())
                {
                    potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
                    //potionInstance.GetComponent<ThrownPotion>().SetEnemies(enemies);
                    potionInstance.transform.up = vecToMouse;
                    potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
                }
                else if (potionInstance.GetComponent<DrinkablePotion>())
                {
                    print("Called Drink");
                    potionInstance.GetComponent<DrinkablePotion>().Drink();
                }
                throwTimer = throwInterval;
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
        }
        if (index >= myPotions.Count)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = myPotions.Count - 1;
        }
    }
}
