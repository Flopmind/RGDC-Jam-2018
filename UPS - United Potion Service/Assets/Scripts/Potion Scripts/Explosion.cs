using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
	public float explosionLength = 1;
    public float radius = 1;
    public PotionEffect effect;

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(EndExplosion());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Enemy"))
        {
            //effect.ApplyEffect(other.GetComponent<VehicleScript>());
			other.GetComponent<HealthScript>().TakeDamage(3);
		}
	}

	IEnumerator EndExplosion()
	{
		yield return new WaitForSeconds(explosionLength);
		Destroy(this.gameObject);
	}

    private void Kill()
    {
        Destroy(this.gameObject);
    }
}
