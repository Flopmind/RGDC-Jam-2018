﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject player;
    public float threshold;
    public float cameraTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 playerPos = player.transform.position;
        if (Mathf.Abs(transform.position.y-player.transform.position.y)>threshold)
        {
            Vector3.Lerp(transform.position, player.transform.position, cameraTime);
        }
	}
}
