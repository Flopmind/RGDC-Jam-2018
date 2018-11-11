﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private List<Vector3> spawnLocations;

    private float playerInRange;
    private GameObject[] enemies;
    private int budget;
    private bool spawned;
    private GameObject player;
    private int lowestCost;

    public float PlayerInRange
    {
        set { playerInRange = value; }
    }

    public GameObject[] Enemies
    {
        set { enemies = value; }
    }

    public int Budget
    {
        set { budget = value; }
    }
    
    public void Initialize()
    {
        spawned = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            throw new System.NullReferenceException("No valid, tagged player in the scene");
        }
        int lowestCost = enemies[0].GetComponent<EnemyScript>().Cost;
        for (int i = 1; i < enemies.Length; i++)
        {
            if (lowestCost > enemies[i].GetComponent<EnemyScript>().Cost)
            {
                lowestCost = enemies[i].GetComponent<EnemyScript>().Cost;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!spawned && budget != default(int) && (transform.position - player.transform.position).magnitude <= playerInRange)
        {
            spawned = true;
            while (budget >= lowestCost && spawnLocations.Count > 0)
            {
                int index;
                do
                {
                    index = Random.Range(0, enemies.Length);
                }
                while (enemies[index].GetComponent<EnemyScript>().Cost > budget);
                int transformIndex = Random.Range(0, spawnLocations.Count);
                Transform nextTransform = parent.transform;
                nextTransform.position = parent.transform.position += spawnLocations[transformIndex];
                spawnLocations.RemoveAt(transformIndex);
                GameObject instance = Instantiate(enemies[index], nextTransform);
                budget -= instance.GetComponent<EnemyScript>().Cost;
            }
        }
	}
}
