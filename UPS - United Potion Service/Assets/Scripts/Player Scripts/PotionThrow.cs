using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotionThrow : MonoBehaviour
{
  	 public enum PotionType{Explosion, Slow, Speed, Health};
    [SerializeField]
    private float potionThrowSpeed = 1;

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

    int numPotions
	{
		get
		{
            int count = 0;
			for (int i = 0; i < potionsCounts.Count; i++)
            {
                count += potionsCounts[i];
            }
            return count;
		}
	}
    private void Start()
    {
        index = 0;
        if (myPotions.Count != potionsCounts.Count)
        {
            throw new System.ArgumentNullException("Bad matchup of potions and potion counts");
        }
        if (GameObject.Find("PotionsText") && GameObject.Find("PotionsText").GetComponent<Text>().text != null && GameObject.Find("ScoreText") && GameObject.Find("ScoreText").GetComponent<Text>().text != null)
        {
            GameObject.Find("PotionsText").GetComponent<Text>().text = "Potions:" + numPotions;
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Potions:" + GetScore();
        }
    }

    // checks for input, instantiates potion and makes potion move
    void Update()
    {
        if (throwTimer <= 0)
        {
            if (Input.GetMouseButtonDown(0) && myPotions.Count > 0 && potionsCounts[index] > 0)
            {
                Vector3 vecToMouse = (MousePos.MousePosition - transform.position);
                float distanceTravel = vecToMouse.magnitude;
                vecToMouse.Normalize();
                GameObject potionInstance = Instantiate(myPotions[index], transform.position + vecToMouse, Quaternion.identity);
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
                --potionsCounts[index];
                if (GameObject.Find("PotionsText") && GameObject.Find("ScoreText"))
                {
                    GameObject.Find("PotionsText").GetComponent<Text>().text = "Potions:" + numPotions;
                    GameObject.Find("ScoreText").GetComponent<Text>().text = "Potions:" + GetScore();
                }
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
        if (index >= myPotions.Count)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = myPotions.Count - 1;
        }

        UpdateUI(); // update the stock and potion UI elements
    }

    private void UpdateUI()
    {
        GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>().text = "" + potionsCounts[index]; // show stock of current potion
        GameObject.Find("PotionIMG").GetComponent<UnityEngine.UI.Image>().sprite = GetCurrentSprite();
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
