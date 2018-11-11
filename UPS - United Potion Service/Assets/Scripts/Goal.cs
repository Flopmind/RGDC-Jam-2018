using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
            ScoreTracker.score = GameObject.FindGameObjectWithTag("Player").GetComponent<PotionThrow>().GetScore();
            SceneManager.LoadScene("Gameover Scene");
		}
	}
}
