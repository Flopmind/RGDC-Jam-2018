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

<<<<<<< HEAD
    protected override void ApplyForces()
    {
        if (knock == Vector3.zero)
        {
            base.ApplyForces();
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(knock.x, knock.y));
            knock = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
=======
    private void OnTriggerEnter2D(Collider2D collision)
>>>>>>> ad8ac161fecd4e52a803fd8a63ce26c6abf10634
    {
        if (collision.otherCollider.CompareTag("Enemy"))
        {
            GetComponent<HealthScript>().TakeDamage(collision.otherCollider.GetComponent<EnemyScript>().Damage);
            Knockback(transform.position - collision.transform.position, knockbackMag);
        }
    }

    private void Knockback(Vector3 direct, float mag)
    {
        knock = direct.normalized * mag;
    }
}
