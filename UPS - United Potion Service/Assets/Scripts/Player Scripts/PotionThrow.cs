using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour 
{
	[SerializeField]
	GameObject potionPrefab;
	[SerializeField]
	float potionThrowSpeed = 1;

    [SerializeField]
    private List<GameObject> myPotions;
    private GameObject[] enemies;
    private int index;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        index = 0;
    }

    // checks for input, instantiates potion and makes potion move
    void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 vecToMouse = (MousePos.MousePosition - transform.position).normalized;
			GameObject potionInstance = Instantiate(potionPrefab, transform.position + vecToMouse, Quaternion.identity);
			potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
            //potionInstance.GetComponent<ThrownPotion>().SetEnemies(enemies);
            potionInstance.transform.up = vecToMouse;
			potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
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
                potionInstance.GetComponent<DrinkablePotion>().Drink();
            }
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
        else if (index <= 0)
        {
            index = myPotions.Count - 1;
        }
    }
}
