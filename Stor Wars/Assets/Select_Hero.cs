using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_Hero : MonoBehaviour
{
    void Start()
	{
		GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

    public void TaskOnClick(){
        GameDirector.heroName = transform.name;
        Camera_Follow.heroName = transform.name;
        SceneManager.LoadScene("KarelScene");
	}
}
