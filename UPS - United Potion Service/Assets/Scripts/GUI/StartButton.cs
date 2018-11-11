using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour 
{

	// Use this for initialization
	public void StartGame()
	{
		SceneManager.LoadSceneAsync("Tom Nonsense", LoadSceneMode.Single);
	}
}
