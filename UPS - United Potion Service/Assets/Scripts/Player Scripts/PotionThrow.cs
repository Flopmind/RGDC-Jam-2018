using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour 
{
	[SerializeField]
    private GameObject potionPrefab;
	[SerializeField]
    private float potionThrowSpeed = 1;
    [SerializeField]
    private float throwInterval;
    [SerializeField]
    protected float maxThrowRange;

    [SerializeField]
    private List<GameObject> myPotions;
    private GameObject[] enemies;
    private int index;
    private float throwTimer = 0;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        index = 0;
    }

    // checks for input, instantiates potion and makes potion move
    void Update () 
	{
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
