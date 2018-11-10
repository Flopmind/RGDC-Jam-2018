using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	 public enum PotionType{Explosion};
	// Use this for initialization
	Dictionary<PotionType, int> invNumbers;
	Dictionary<PotionType, GameObject> invItems;
	DamageEffect dmg;
	[SerializeField]
	GameObject explosionPrefab;
	void Start()
	{
		invNumbers = new Dictionary<PotionType, int>();
		invItems = new Dictionary<PotionType, GameObject>();
		invNumbers.Add(PotionType.Explosion, 5);
		invItems.Add(PotionType.Explosion, explosionPrefab);
	}

	public GameObject RetrieveItem(PotionType pt)
	{
		if (invNumbers[pt] > 0)
		{
			--invNumbers[pt];
			return invItems[pt];
		}
		else
		{
			return null;
		}
	}
}
