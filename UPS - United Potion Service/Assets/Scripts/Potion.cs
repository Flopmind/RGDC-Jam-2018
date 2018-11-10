using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour 
{
	[SerializeField]
	float timeUntilEffect = 1;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(WaitUntilEffect());

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator WaitUntilEffect()
	{
		yield return new WaitForSeconds(timeUntilEffect);
		TriggerEffect();
	}

	void TriggerEffect()
	{
		Destroy(gameObject);
	}
}
