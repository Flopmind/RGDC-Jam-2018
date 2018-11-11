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
        string end = "";
        if (ScoreTracker.victory)
        {
            end += "Congratulations! You won!";
            end += "\nYour final score is " + ScoreTracker.score;
        }
        else
        {
            end += "Sorry! You lost!";
        }
        scoreText.text = end;
	}
}
