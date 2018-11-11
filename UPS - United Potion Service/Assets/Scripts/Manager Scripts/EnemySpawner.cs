using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private List<Vector3> spawnLocations;

    [SerializeField]
    private float playerInRange;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int budget;
    private bool spawned;
    private bool initialized;
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

    private void Start()
    {
        initialized = false;
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
        initialized = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (initialized && !spawned && budget != default(int) && (transform.position - player.transform.position).magnitude <= playerInRange)
        {
            spawned = true;
            int bigCount = 0;
            while (budget >= lowestCost && spawnLocations.Count > 0)
            {
                ++bigCount;
                int index;
                int count = 0;
                do
                {
                    ++count;
                    index = Random.Range(0, enemies.Length);
                }
                while (enemies[index].GetComponent<EnemyScript>().Cost > budget && count < 20);
                print("count - " + count);
                int transformIndex = Random.Range(0, spawnLocations.Count);
                Vector3 nextTransform = parent.transform.position;
                nextTransform += spawnLocations[transformIndex];
                spawnLocations.RemoveAt(transformIndex);
                GameObject instance = Instantiate(enemies[index], nextTransform, Quaternion.identity);
                budget -= instance.GetComponent<EnemyScript>().Cost;
            }
            print("bigCount - " + bigCount);
        }
	}
}