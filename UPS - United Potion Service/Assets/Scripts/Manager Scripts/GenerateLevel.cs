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
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
