using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private float playerInRange;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int budget;

    private bool spawned;
    private GameObject player;
    private int lowestCost;

    // Use this for initialization
    void Start ()
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
		if (!spawned && (transform.position - player.transform.position).magnitude <= playerInRange)
        {
            spawned = true;
            while (budget >= lowestCost)
            {
                int index = Random.Range(0, enemies.Length);
            }
        }
	}
}
