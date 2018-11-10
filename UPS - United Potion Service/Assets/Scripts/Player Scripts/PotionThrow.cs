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
    private float throwInterval = 2;
    [SerializeField]
    protected float maxThrowRange = 6;
    [SerializeField]
    private List<GameObject> myPotions;

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
            if (Input.GetMouseButtonDown(0))
            {
                potionToInstantiate = inv.RetrieveItem(PlayerInventory.PotionType.Explosion);
                if (potionToInstantiate != null)
                {
                    Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                    float distanceTravel = vecToMouse.magnitude;
                    vecToMouse.Normalize();
                    GameObject potionInstance = Instantiate(potionPrefab, transform.position + vecToMouse, Quaternion.identity);
                    potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
                    potionInstance.GetComponent<ThrownPotion>().SetDistances(transform.position, maxThrowRange, distanceTravel);
                    potionInstance.transform.up = vecToMouse;
                    potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
                    throwTimer = throwInterval;
                }
            }
            else if (Input.GetMouseButtonDown(1) && myPotions.Count > 0)
            {
                Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                float distanceTravel = vecToMouse.magnitude;
                vecToMouse.Normalize();
                GameObject potionInstance = Instantiate(myPotions[index], transform.position + vecToMouse, Quaternion.identity);
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
