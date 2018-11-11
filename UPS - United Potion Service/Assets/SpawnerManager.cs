using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    [SerializeField]
    private float playerInRange;
    [SerializeField]
    private GameObject[] enemies;

    private GameObject[] spawners;
    private bool started;
    private GameObject manager;

	// Use this for initialization
	void Start()
    {
        started = false;
        manager = GameObject.Find("Manager");
    }

    private void Initialize()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<EnemySpawner>().PlayerInRange = playerInRange;
            spawner.GetComponent<EnemySpawner>().Enemies = enemies;
            spawner.GetComponent<EnemySpawner>().Budget = 12;
            spawner.GetComponent<EnemySpawner>().Initialize();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (!started && manager.GetComponent<GenerateLevel>().Length + 1 == GameObject.FindGameObjectsWithTag("Spawner").Length)
        {
            started = true;
            Initialize();
        }
	}
}
