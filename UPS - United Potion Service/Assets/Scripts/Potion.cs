using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour 
{
	[SerializeField]
	float timeUntilEffect = 1;
	Vector3 activationLocation;
	public Vector3 ActivationLocation
	{
		get
		{
			return activationLocation;
		}
		set
		{
			activationLocation = value;
		}
	}
	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(WaitUntilEffect());

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.SqrMagnitude(transform.position - activationLocation) < .01)
		{
			TriggerEffect();
		}
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
