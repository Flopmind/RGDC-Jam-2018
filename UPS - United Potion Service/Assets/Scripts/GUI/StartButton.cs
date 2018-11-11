using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour 
{

    public string destinationScene;

	public void StartGame()
	{
		SceneManager.LoadSceneAsync(destinationScene, LoadSceneMode.Single);
	}
}
