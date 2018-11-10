using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevel : MonoBehaviour
{
    // prefab hooks and length of level to generate
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private float length = 5;
    [SerializeField] private float levelSize = 20;

    [Header("Grid to insert prefabs")]
    [SerializeField] private Transform grid;

    // Use this for initialization
    void Start()
    {
        GameObject startObj = GameObject.Instantiate(start, new Vector3(0, 0, 0), Quaternion.identity); // place start
        startObj.transform.SetParent(grid);
        // place inner pieces
        float currentY = levelSize;
        int lastGen = -1; // avoid the same tile twice in a row
        for (int i = 0; i < length; i++)
        {
            int num;
            do
            {
                num = Random.Range(0, prefabs.Count);
            }
            while (num == lastGen); // if duplicate, roll again
            lastGen = num;

            GameObject obj = GameObject.Instantiate(prefabs[num], new Vector3(0, currentY, 0), Quaternion.identity);
            obj.transform.SetParent(grid);

            currentY += levelSize;
        }

        GameObject endObj = GameObject.Instantiate(end, new Vector3(0, currentY, 0), Quaternion.identity); // end cap
        endObj.transform.SetParent(grid);

    }
}
/* Original Code
 * 
 * public class GenerateLevel : MonoBehaviour 
{
	[SerializeField]
	GameObject wallPrefab;
	[SerializeField]
	float levelWidth;
	[SerializeField]
	float levelHeight;
	[Range(0.0f, 100.0f)]
	[SerializeField]
	float wallProbabilityThreshold;
	[SerializeField]
	Vector3 wallSize;
	// Use this for initialization
	void Start () 
	{
		Vector3 genStart = new Vector3(-wallSize.x * (levelWidth - 1) / 2, wallSize.y * (levelHeight - 1) / 2, 0);
		Vector3 currentLoc = genStart;
		// randomly generate walls within level
		for (int i = 0; i < levelHeight; ++i)
		{
			for (int j = 0; j < levelWidth; ++j)
			{
				float wallProbability = Random.Range(0, 100);
				if (wallProbability < wallProbabilityThreshold)
				{
					GameObject wallInstance = Instantiate(wallPrefab, currentLoc, Quaternion.identity);
					wallInstance.transform.localScale = wallSize;
				}
				currentLoc += new Vector3(wallSize.x, 0, 0);
			}
			currentLoc.x = genStart.x;
			currentLoc.y -= wallSize.y;
		}
		currentLoc = genStart + new Vector3(0, wallSize.y);
		// generate bounding walls for level
		for (int i = 0; i < 2; ++i)
		{
			for (int j = 0; j < levelWidth; ++j)
			{
				Instantiate(wallPrefab, currentLoc, Quaternion.identity);
				currentLoc.x += wallSize.x;
			}
			currentLoc = genStart - new Vector3(0, wallSize.y * levelHeight);
		}
	}


}*/
