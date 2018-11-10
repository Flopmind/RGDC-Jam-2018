using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionEffect : MonoBehaviour
{

    [SerializeField]
    protected float effectTimer;

    public float Timer
    {
        get { return effectTimer; }
        set { effectTimer = value; }
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
    }

}
