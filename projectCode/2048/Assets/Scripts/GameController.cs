using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] allCells;

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
    }

    public void SpawnFill()
    {
        float chance = Random.Range(0f, 1f);
        Debug.Log(chance);

        if (chance < 0.2f)
        {
            return;
        }
        else if (chance < 0.8f)
        {
            int whichSpawn = Random.Range(0, allCells.Length);
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            Debug.Log(2);
        }
        else
        {
            int whichSpawn = Random.Range(0, allCells.Length);
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            Debug.Log(4);
        }
    }
}
