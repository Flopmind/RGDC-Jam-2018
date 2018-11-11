using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        scoreText.text = "Final Score: " + ScoreTracker.score;
	}
}
