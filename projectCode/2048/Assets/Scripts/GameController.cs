using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static int ticker; // track how many cells recieved this action, then call SpawnFill function

    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] allCells;

    public static Action<string> slide;
    public int myScore;

    [SerializeField] Text scoreDisplay;

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
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnFill();
        //}

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ticker = 0;
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ticker = 0;
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ticker = 0;
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ticker = 0;
            slide("a");
        }
    }

    public void SpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].childCount != 0)
        {
            SpawnFill();
            return;
        }

        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);

        if (chance < 0.2f)
        {
            return;
        }
        else if (chance < 0.8f)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);

            Fill tempFillScript = tempFill.GetComponent<Fill>();
            allCells[whichSpawn].GetComponent<Cell>().fill = tempFillScript;
            tempFillScript.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);

            Fill tempFillScript = tempFill.GetComponent<Fill>();
            allCells[whichSpawn].GetComponent<Cell>().fill = tempFillScript;
            tempFillScript.FillValueUpdate(4);
        }
    }


    public void StartSpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].childCount != 0)
        {
            SpawnFill();
            return;
        }

        GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);

        Fill tempFillScript = tempFill.GetComponent<Fill>();
        allCells[whichSpawn].GetComponent<Cell>().fill = tempFillScript;
        tempFillScript.FillValueUpdate(2);
    }

    public void ScoreUpdate(int scoreIn)
    {
        myScore += scoreIn;
        scoreDisplay.text = myScore.ToString();
    }
}
