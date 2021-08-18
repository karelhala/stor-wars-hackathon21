using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePreserver : MonoBehaviour
{
    private static int m_score;

    public int score
    {
        get { return m_score; }
        set { m_score = value; }
    }
}
