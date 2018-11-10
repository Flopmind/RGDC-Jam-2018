using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : VehicleScript {

    [SerializeField]
    private float knockbackMag = 1;

	void Update ()
    {
        VehicleUpdate();
    }

    protected override Vector3 CalculateForces()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            GetComponent<Animator>().SetBool("Running", true); // update Running value to reflect input
            if (Input.GetAxis("Horizontal") != 0)
            {
                GetComponent<Animator>().SetBool("FacingR", Input.GetAxis("Horizontal") > 0); // update FacingR
            }
            return (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized);
        }
        else
        {
            GetComponent<Animator>().SetBool("Running", false); // update Running value to reflect input
        }
        return Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GetComponent<HealthScript>().
                TakeDamage
                (
                collision
                .GetComponent<EnemyScript>()
                .Damage);
            Knockback(transform.position - collision.transform.position, knockbackMag);
        }
    }

    private void Knockback(Vector3 direct, float mag)
    {
        Vector2 direct2 = new Vector2(direct.x, direct.y);
        GetComponent<Rigidbody2D>().AddForce(mag * direct2);
    }
}
