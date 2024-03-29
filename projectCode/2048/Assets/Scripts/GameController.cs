using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static int ticker; // track how many cells recieved this action, then call SpawnFill function

    [SerializeField] GameObject fillPrefab;
    [SerializeField] Cell[] allCells;

    public static Action<string> slide;
    public int myScore;

    [SerializeField] Text scoreDisplay;

    int isGameOver;
    [SerializeField] GameObject gameOverPanel;

    public Color[] fillColors;
    public Color defaultColor;

    [SerializeField] int winningScore;
    [SerializeField] GameObject winningPanel;
    bool hasWon;

    bool inputDisabled = false;

    float currentTime;
    float timeCutoff;
    bool timeStopped = false;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawnFill();
        StartSpawnFill();

        timeCutoff = Time.time + 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCutoff > Time.time && !timeStopped)
        {
            currentTime += Time.deltaTime;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnFill();
        //}

        if (inputDisabled)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            timeCutoff = Time.time + 30;

            ticker = 0;
            isGameOver = 0;
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            timeCutoff = Time.time + 30;

            ticker = 0;
            isGameOver = 0;
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            timeCutoff = Time.time + 30;

            ticker = 0;
            isGameOver = 0;
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            timeCutoff = Time.time + 30;

            ticker = 0;
            isGameOver = 0;
            slide("a");
        }
    }

    public void SpawnFill()
    {
        bool isFull = true;
        for (int i = 0; i < allCells.Length; i++)
        {
            if (allCells[i].fill == null)
            {
                isFull = false;
            }
        }

        if (isFull)
        {
            return;
        }

        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].transform.childCount != 0)
        {
            SpawnFill();
            return;
        }

        float chance = UnityEngine.Random.Range(0f, 1f);
        //Debug.Log(chance);

        if (chance < 0.2f)
        {
            return;
        }
        else if (chance < 0.8f)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);

            Fill tempFillScript = tempFill.GetComponent<Fill>();
            allCells[whichSpawn].GetComponent<Cell>().fill = tempFillScript;
            tempFillScript.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);

            Fill tempFillScript = tempFill.GetComponent<Fill>();
            allCells[whichSpawn].GetComponent<Cell>().fill = tempFillScript;
            tempFillScript.FillValueUpdate(4);
        }
    }


    public void StartSpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].transform.childCount != 0)
        {
            SpawnFill();
            return;
        }

        GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);

        Fill tempFillScript = tempFill.GetComponent<Fill>();
        allCells[whichSpawn].GetComponent<Cell>().fill = tempFillScript;
        tempFillScript.FillValueUpdate(2);
    }

    public void ScoreUpdate(int scoreIn)
    {
        myScore += scoreIn;
        scoreDisplay.text = myScore.ToString();
    }

    public void GameOverCheck()
    {
        isGameOver++;
        if(isGameOver >= 16)
        {
            if (PlayerPrefs.GetInt("HighScore") < myScore)
            {
                PlayerPrefs.SetInt("HighScore", myScore);
            }

            if (!timeStopped)
            {
                currentTime += PlayerPrefs.GetInt("TimeSpent");
                PlayerPrefs.SetInt("TimeSpent", (int)currentTime);
            }

            timeStopped = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Return()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void WinningCheck(int highestFill)
    {
        if (hasWon)
        {
            return;
        }

        if (highestFill == winningScore)
        {
            if (PlayerPrefs.GetInt("HighScore") < myScore)
            {
                PlayerPrefs.SetInt("HighScore", myScore);
            }

            winningPanel.SetActive(true);
            inputDisabled = true;
            hasWon = true;
        }
    }

    public void KeepPlaying()
    {
        winningPanel.SetActive(false);
        inputDisabled = false;
    }
}
