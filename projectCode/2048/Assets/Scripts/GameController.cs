using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] allCells;

    public static Action<string> slide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFill();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
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
            tempFillScript.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);

            Fill tempFillScript = tempFill.GetComponent<Fill>();
            tempFillScript.FillValueUpdate(4);
        }
    }
}
