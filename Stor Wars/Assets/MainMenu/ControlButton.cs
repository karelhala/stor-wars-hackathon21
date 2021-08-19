using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
	void Start()
	{
		GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
	}

	void TaskOnClick()
	{
		var helpImage = GameObject.FindGameObjectsWithTag("ControlScreen")[0];

		if(helpImage.transform.localScale.x == 0)
        {
			GameObject.FindGameObjectsWithTag("ControlScreen")[0].transform.localScale = new Vector3(1, 1, 1);
        } else
        {
			GameObject.FindGameObjectsWithTag("ControlScreen")[0].transform.localScale = new Vector3(0, 0, 0);
		}
	}
}
