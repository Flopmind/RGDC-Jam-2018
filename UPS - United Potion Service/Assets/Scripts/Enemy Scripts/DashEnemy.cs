using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : EnemyScript
{
    [SerializeField]
    protected float dashInterval;
    [SerializeField]
    protected float dashLength;
    [SerializeField]
    protected float dashMag;
    [SerializeField]
    protected float leashRange;

    protected bool dashReady;
    protected float dashTimer;
    protected float dashLengthTimer;
    protected Vector3 dashVector;
    protected bool wasInRange;

    private void Start()
    {
        wasInRange = false;
        Initialize();
        dashReady = false;
        dashTimer = dashInterval;
        dashLengthTimer = 0;
    }

    private void Update()
    {
        EnemyUpdate();
    }

    protected override Vector3 CalculateForces()
    {
        Vector3 netForce = Vector3.zero;
        if (target)
        {
            if ((target.transform.position - transform.position).magnitude >= leashRange)
            {
                dashLengthTimer = 0;
                wasInRange = false;
            }
            dashLengthTimer -= Time.deltaTime;
            if (dashLengthTimer <= 0)
            {
                if (dashTimer <= 0)
                {
                    dashReady = true;
                }
                else
                {
                    dashTimer -= Time.deltaTime;
                }
            }

            netForce = Seek(target).normalized * moveMag;
            if (dashReady)
            {
                dashReady = false;
                dashLengthTimer = dashLength;
                dashVector = (target.transform.position - transform.position).normalized + (Seek(target).normalized * moveMag);
                dashTimer = dashInterval;
                if ((target.transform.position - transform.position).magnitude <= leashRange)
                {
                    wasInRange = true;
                }
            }
            if (dashLengthTimer > 0)
            {
                netForce = dashVector * dashMag;
            }
        }
        return netForce;
    }

    protected override void ApplyForces()
    {
        if (knock == Vector3.zero)
        {
            GetComponent<Rigidbody2D>().velocity = CalculateForces();

            if (ContainsEffect("Speed") && !ContainsEffect("Slow"))
            {
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * speedMag;
            }
            else if (ContainsEffect("Slow"))
            {
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * slowMag;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(knock.x, knock.y));
            knock = Vector3.zero;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (!collision.collider.CompareTag("Enemy") && dashLengthTimer > 0)
        {
            dashLengthTimer = 0;
        }
    }
}