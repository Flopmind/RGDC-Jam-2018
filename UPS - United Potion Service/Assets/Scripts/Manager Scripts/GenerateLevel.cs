using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour 
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
}
