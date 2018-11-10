using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
	float explosionLength = 1;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(EndExplosion());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	IEnumerator EndExplosion()
	{
		yield return new WaitForSeconds(explosionLength);
		Destroy(this.gameObject);
	}
}
