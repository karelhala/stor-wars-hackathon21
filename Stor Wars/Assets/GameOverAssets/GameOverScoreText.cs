using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour
{
    void Start()
    {
        var scorePreserved = GameObject.FindGameObjectsWithTag("ScorePreserver")[0].GetComponent<ScorePreserver>().score;

        GetComponent<Text>().text = $"Your score is {scorePreserved}";
    }
}
