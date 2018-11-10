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
    PlayerInventory inv;
    private float throwTimer = 0;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        index = 0;
        inv = GetComponent<PlayerInventory>();
    }

    // checks for input, instantiates potion and makes potion move
    void Update () 
	{
        GameObject potionToInstantiate = null;
		// if (Input.GetMouseButtonDown(0))
		// {
        //     potionToInstantiate = inv.RetrieveItem(PlayerInventory.PotionType.Explosion);
        //     if (potionToInstantiate != null)
        //     {
        //         Vector3 vecToMouse = (MousePos.MousePosition - transform.position).normalized; 
        //         GameObject potionInstance = Instantiate(potionToInstantiate, transform.position + vecToMouse, Quaternion.identity);
        //         potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
        //         //potionInstance.GetComponent<ThrownPotion>().SetEnemies(enemies);
        //         potionInstance.transform.up = vecToMouse;
        //         potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
        //     }
		// }
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
            if (throwTimer <= 0)
            {
<<<<<<< HEAD
<<<<<<< HEAD
                Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                float distanceTravel = vecToMouse.magnitude;
                vecToMouse.Normalize();
                GameObject potionInstance = Instantiate(myPotions[index], transform.position + vecToMouse, Quaternion.identity);
                if (potionInstance.GetComponent<ThrownPotion>())
=======
                if (Input.GetMouseButtonDown(0))
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
=======
                if (Input.GetMouseButtonDown(0))
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
                {
                    Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                    float distanceTravel = vecToMouse.magnitude;
                    vecToMouse.Normalize();
                    GameObject potionInstance = Instantiate(potionPrefab, transform.position + vecToMouse, Quaternion.identity);
                    potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
                    potionInstance.GetComponent<ThrownPotion>().SetDistances(transform.position, maxThrowRange, distanceTravel);
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
                    //potionInstance.GetComponent<ThrownPotion>().SetEnemies(enemies);
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
                    potionInstance.transform.up = vecToMouse;
                    potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
                    throwTimer = throwInterval;
                }
                else if (Input.GetMouseButtonDown(1) && myPotions.Count > 0)
                {
<<<<<<< HEAD
<<<<<<< HEAD
                    print("Called Drink");
                    potionInstance.GetComponent<DrinkablePotion>().Drink();
                    Destroy(potionInstance);
=======
=======
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
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
<<<<<<< HEAD
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
=======
>>>>>>> 2b77533a29b44a5fdca4ab299483cf078a8afe79
                }
            }
        }
        else
        {
            throwTimer -= Time.deltaTime;
        }
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     --index;
        // }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     ++index;
        // }
        // if (index >= myPotions.Count)
        // {
        //     index = 0;
        // }
        // else if (index < 0)
        // {
        //     index = myPotions.Count - 1;
        // }
    }
}
