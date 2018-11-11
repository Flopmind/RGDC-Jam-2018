using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotionThrow : MonoBehaviour
{
  	 public enum PotionType{Explosion, Slow, Speed, Health};
    [SerializeField]
    private float potionThrowSpeed = 1;
    Dictionary<PotionType, int> invNumbers;
	Dictionary<PotionType, GameObject> invItems;

    [SerializeField]
    private float throwInterval = 2;
    [SerializeField]
    protected float maxThrowRange = 6;
    [SerializeField]
    private List<GameObject> myPotions;
    [SerializeField]
    private List<int> potionsCounts;

    private GameObject[] enemies;
    private int index;
    private float throwTimer = 0;
   	[SerializeField]
	int numExplosions;
	[SerializeField]
	int numSlows;
	[SerializeField]
	int numSpeeds;
	[SerializeField]
	int numHealths;
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
    private void Start()
    {
   		invNumbers = new Dictionary<PotionType, int>();
		invItems = new Dictionary<PotionType, GameObject>();
        invNumbers.Add(PotionType.Health, numHealths);
		invNumbers.Add(PotionType.Slow, numSlows);
		invNumbers.Add(PotionType.Speed, numSpeeds);
		invNumbers.Add(PotionType.Explosion, numExplosions);
		invItems.Add(PotionType.Explosion, explosionPrefab);
		invItems.Add(PotionType.Health, healthPrefab);
		invItems.Add(PotionType.Slow, slowPrefab);
		invItems.Add(PotionType.Speed, speedPrefab);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        index = 0;
        if (myPotions.Count != potionsCounts.Count)
        {
            throw new System.ArgumentNullException("Bad matchup of potions and potion counts");
        }
        GameObject.Find("PotionsText").GetComponent<Text>().text = "Potions:" + numPotions;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Potions:" + totalScore;
    }

    // checks for input, instantiates potion and makes potion move
    void Update()
    {
        if (throwTimer <= 0)
        {
            if (Input.GetMouseButtonDown(0) && myPotions.Count > 0 && invNumbers[(PotionType)index] > 0)
            {
                Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                float distanceTravel = vecToMouse.magnitude;
                vecToMouse.Normalize();
                GameObject potionInstance = Instantiate(invItems[(PotionType)index], transform.position + vecToMouse, Quaternion.identity);
                if (potionInstance.GetComponent<ThrownPotion>())
                {
                    potionInstance.GetComponent<ThrownPotion>().ActivationLocation = MousePos.MousePosition;
                    potionInstance.GetComponent<ThrownPotion>().SetDistances(transform.position, maxThrowRange, distanceTravel);
                    potionInstance.transform.up = vecToMouse;
                    potionInstance.GetComponent<Rigidbody2D>().velocity = vecToMouse * potionThrowSpeed;
                    throwTimer = throwInterval;
                }
                else if (potionInstance.GetComponent<DrinkablePotion>())
                {
                    potionInstance.GetComponent<DrinkablePotion>().Initialize();
                    potionInstance.GetComponent<DrinkablePotion>().Drink();
                    Destroy(potionInstance);
                }
                throwTimer = throwInterval;
                //--potionsCounts[index];
                --invNumbers[(PotionType)index];
                GameObject.Find("PotionsText").GetComponent<Text>().text = "Potions:" + numPotions;
                GameObject.Find("ScoreText").GetComponent<Text>().text = "Potions:" + totalScore;
            }
        }
        else
        {
            throwTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            --index;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ++index;
            print(index);
        }
        if (index > myPotions.Count)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = myPotions.Count - 1;
        }
    }

    public int GetScore()
    {
        int score = 0;
        for (int i = 0; i < myPotions.Count; i++)
        {
            score += myPotions[i].GetComponent<Potion>().Score * potionsCounts[i];
        }
        return score;
    }
    
    public Sprite GetCurrentSprite()
    {
        return myPotions[index].GetComponent<SpriteRenderer>().sprite;
    }

    public GameObject CurrentPotion
    {
        get { return myPotions[index]; }
    }
}
