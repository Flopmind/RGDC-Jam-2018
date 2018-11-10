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

    protected bool dashReady;
    protected float dashTimer;
    protected float dashLengthTimer;
    protected Vector3 targetLoc;

    private void Start()
    {
        Initialize();
        dashReady = false;
        dashTimer = dashInterval;
        dashLengthTimer = 0;
        targetLoc = Vector3.zero;
    }

    private void Update()
    {
        EnemyUpdate();

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
    }

    protected override Vector3 CalculateForces()
    {
        Vector3 netForce = Vector3.zero;
        if (target)
        {
            netForce += Seek(target).normalized * moveMag;
            if (dashReady)
            {
                dashReady = false;
                dashLengthTimer = dashLength;
            }
            if (dashLengthTimer > 0)
            {
                netForce = Seek(target).normalized * dashMag;
            }
            else
            {
                print("not dashing");
                dashTimer = dashInterval;
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
}