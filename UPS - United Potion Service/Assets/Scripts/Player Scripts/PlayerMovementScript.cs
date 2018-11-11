using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : VehicleScript {

    [SerializeField]
    private float knockbackMag = 1;

    private void Start()
    {
        knockTimer = 0;
        knock = Vector3.zero;
    }

    void Update ()
    {
        knockTimer -= Time.deltaTime;
        if (knockTimer <= 0)
        {
            knock = Vector3.zero;
        }
        VehicleUpdate();
    }

    protected override Vector3 CalculateForces()
    {
        Vector3 forces = Vector3.zero;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            GetComponent<Animator>().SetBool("Running", true); // update Running value to reflect input
            if (Input.GetAxis("Horizontal") != 0)
            {
                GetComponent<Animator>().SetBool("FacingR", Input.GetAxis("Horizontal") > 0); // update FacingR
            }
            forces += (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized);
        }
        GetComponent<Animator>().SetBool("Running", false); // update Running value to reflect input
        forces += knock;
        return forces;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GetComponent<HealthScript>().TakeDamage(collision.collider.GetComponent<EnemyScript>().Damage);
            Knockback(transform.position - collision.transform.position, knockbackMag);
        }
    }

    private void Knockback(Vector3 direct, float mag)
    {
        knockTimer = knockCount;
        knock = direct.normalized * mag;
    }
}
