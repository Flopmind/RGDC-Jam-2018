using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    [SerializeField]
    private float playerInRange;
    [SerializeField]
    private GameObject[] enemies;

    private GameObject[] spawners;

	// Use this for initialization
	void Start ()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        print(spawners);
        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<EnemySpawner>().PlayerInRange = playerInRange;
            spawner.GetComponent<EnemySpawner>().Enemies = enemies;
            spawner.GetComponent<EnemySpawner>().Initialize();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
