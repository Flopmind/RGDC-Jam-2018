using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour 
{
	Text controlsText;
	void Start()
	{
		controlsText = GameObject.Find("ControlsText").GetComponent<Text>();
	}

	public void ToggleControls()
	{
		controlsText.enabled = !controlsText.enabled;
	}
}
