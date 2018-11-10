using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour 
{
	[SerializeField]
	GameObject potionPrefab;
	[SerializeField]
	float potionThrowSpeed = 1;

    private GameObject[] enemies;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // checks for input, instantiates potion and makes potion move
    void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 vecToMouse = (MousePos.MousePosition - transform.position).normalized;
			GameObject potionInstance = Instantiate(potionPrefab, transform.position + vecToMouse, Quaternion.identity);
			potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
            potionInstance.GetComponent<ThrownPotion>().SetEnemies(enemies);
            potionInstance.transform.up = vecToMouse;
			potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
		}
	}
}
