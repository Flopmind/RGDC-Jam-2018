using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour 
{
	Text potionsText;
	int numPotions = 5;
	public delegate void UpdateUI(int newData);
	public static UpdateUI UpdatePotions;
	// Use this for initialization
	void Start ()
	{
		potionsText = GameObject.Find("PotionsText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
