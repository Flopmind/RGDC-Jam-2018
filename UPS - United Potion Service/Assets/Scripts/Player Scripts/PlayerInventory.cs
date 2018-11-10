using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour {
	 public enum PotionType{Explosion};
	// Use this for initialization
	Dictionary<PotionType, int> invNumbers;
	Dictionary<PotionType, GameObject> invItems;
	DamageEffect dmg;
	[SerializeField]
	GameObject explosionPrefab;
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
		invNumbers.Add(PotionType.Explosion, 5);
		invItems.Add(PotionType.Explosion, explosionPrefab);
		GameObject.Find("PotionsText").GetComponent<Text>().text = "Potions:" + numPotions;
		GameObject.Find("ScoreText").GetComponent<Text>().text = "Potions:" + totalScore;

	}

	public GameObject RetrieveItem(PotionType pt)
	{
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
