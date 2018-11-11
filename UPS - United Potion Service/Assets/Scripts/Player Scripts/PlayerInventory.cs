using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour {
	 public enum PotionType{Explosion, Slow, Speed, Health};
	// Use this for initialization
	Dictionary<PotionType, int> invNumbers;
	Dictionary<PotionType, GameObject> invItems;
	[SerializeField]
	GameObject explosionPrefab;
	[SerializeField]
	GameObject slowPrefab;
	[SerializeField]
	GameObject speedPrefab;
	[SerializeField]
	GameObject healthPrefab;
	int numPotions
	{
		get
		{
			int result = 0;
			foreach (int i in invNumbers.Values)
			{
				result += i;
			}
			return result;
		}
	}
	int totalScore
	{
		get
		{
			int result = 0;
			foreach(PotionType pt in invItems.Keys)
			{
				result += invItems[pt].GetComponent<Potion>().Score * invNumbers[pt];
			}
			return result;
		}
	}
	void Start()
	{
		invNumbers = new Dictionary<PotionType, int>();
		invItems = new Dictionary<PotionType, GameObject>();
		invNumbers.Add(PotionType.Health, 5);
		invNumbers.Add(PotionType.Slow, 5);
		invNumbers.Add(PotionType.Speed, 5);
		invNumbers.Add(PotionType.Explosion, 5);
		invItems.Add(PotionType.Explosion, explosionPrefab);
		invItems.Add(PotionType.Health, healthPrefab);
		invItems.Add(PotionType.Slow, slowPrefab);
		invItems.Add(PotionType.Speed, speedPrefab);
		GameObject.Find("PotionsText").GetComponent<Text>().text = "Potions:" + numPotions;
		GameObject.Find("ScoreText").GetComponent<Text>().text = "Potions:" + totalScore;

	}

	public GameObject RetrieveItem(PotionType pt)
	{
		if (GameObject.Find("PotionsText") == null || GameObject.Find("ScoreText") == null)
		{
			return null;
		}
		if (invNumbers[pt] > 0)
		{
			--invNumbers[pt];
			GameObject.Find("PotionsText").GetComponent<Text>().text = "Potions:" + numPotions;
			GameObject.Find("ScoreText").GetComponent<Text>().text = "Potions:" + totalScore;
			return invItems[pt];
		}
		else
		{
			return null;
		}
	}
}
