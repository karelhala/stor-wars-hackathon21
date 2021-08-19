using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private int wawe = 0;
    private int score = 0;
    private int enemiesCounter = 0;
    private int lastSpawnIndex = 0;

    public static string heroName;

    public Text waweText;
    public Text scoreBoard;
    public GameObject enemyStormTrooper;
    public GameObject enemyRebel;
    private GameObject enemyPrefab;

    private float countdown;
    private bool nextWave;

    private GameObject[] spawners;

    public void IncreaseScore(int additionalScore)
    {
        score += additionalScore;
        scoreBoard.text = score.ToString();
        GameObject.FindGameObjectsWithTag("ScorePreserver")[0].GetComponent<ScorePreserver>().score = score;
    }

    public void NextWave()
    {
        wawe += 1;
        countdown = 10;
        nextWave = true;
    }

    public void GenerateWave()
    {
        waweText.text = $"Wave {wawe}";
        nextWave = false;

        var currentDifficultyLevel = (int)(wawe / spawners.Length);
        var deployedEnemies = wawe % spawners.Length == 0 ? spawners.Length : wawe % spawners.Length;


        for (int i = 1; i <= deployedEnemies; i++)
        {
            GenerateEnemy(currentDifficultyLevel);
        }
    }

    private float selectMaxFloat(float a, float b)
    {
        return a > b ? a : b;
    }


    private void GenerateEnemy(int currentDifficultyLevel)
    {
        lastSpawnIndex = lastSpawnIndex + 1;

        if(lastSpawnIndex + 1 > spawners.Length)
        {
            lastSpawnIndex = 0;
        }

        var enemy = Instantiate(enemyPrefab, spawners[lastSpawnIndex].transform.position, new Quaternion());

        var newTimeToReload = selectMaxFloat(8 - (1 * currentDifficultyLevel), 1);
        var newMinimalDistance = 4 + (1 * currentDifficultyLevel);
        var newSpeed = 0.03f + (0.05f * currentDifficultyLevel);

        enemy.GetComponent<Enemy>().SetStats(newTimeToReload, newMinimalDistance, newSpeed, (int)selectMaxFloat(currentDifficultyLevel, 1));
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = heroName == "Vader" ? enemyRebel : enemyStormTrooper;
        var stats = GameObject.FindGameObjectsWithTag("GameStats");
        waweText = findGOByName(stats, "WaveText").GetComponent<Text>();
        scoreBoard = findGOByName(stats, "ScoreText").GetComponent<Text>();

        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        NextWave();
    }

    GameObject findGOByName(GameObject[] arr, string name) {
        for (int i = 0; i < arr.Length; i++) 
        {
            if (arr[i].transform.name == name)
            {
                return arr[i];
            }
        }
    
        Debug.Log ("No item witth name '" + name + "'.");
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            waweText.text = $"Next wave in {(int)countdown}";
        } else if (nextWave)
        {
            GenerateWave();
        }

        if (Input.GetKeyDown("n"))
        {
            wawe += 1;
            countdown = 0;
            GenerateWave();
        }
    }

    public void AddEnemy()
    {
        enemiesCounter += 1;
    }

    public void RemoveEnemy(int enemyValue)
    {
        enemiesCounter -= 1;
        IncreaseScore(enemyValue);

        if (enemiesCounter == 0)
        {
            NextWave();
        }
    }
}
