using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;

public class UploadScore : MonoBehaviour
{
	private Button btn;
	private InputField inp;
	private bool alreadySubmitted = false;

	void Start()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(() => TaskOnClick());

		inp = GameObject.FindGameObjectsWithTag("EnterName")[0].GetComponent<InputField>();
	}

    private void FixedUpdate()
    {
        if (!alreadySubmitted && inp.text.Length > 0)
        {
			btn.enabled = true;
        } else
        {
			btn.enabled = false;
        }
    }

    void TaskOnClick()
	{
		alreadySubmitted = true;
		var score = GameObject.FindGameObjectsWithTag("ScorePreserver")[0].GetComponent<ScorePreserver>().score;

		UnityWebRequest.Get($"http://dreamlo.com/lb/KÓD TADY/add/{inp.text}/{score}").SendWebRequest();
    }
}
