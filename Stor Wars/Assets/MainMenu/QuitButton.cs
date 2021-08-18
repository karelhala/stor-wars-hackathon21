using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{ 
	void Start()
	{
		GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
	}

	void TaskOnClick()
	{
		Application.Quit();
	}
}
