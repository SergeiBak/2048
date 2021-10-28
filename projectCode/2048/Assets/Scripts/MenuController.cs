using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject confirmationPanel;

    [SerializeField] Text highScore;
    [SerializeField] Text highBlock;
    [SerializeField] Text timeSpent;

    int minutes;
    int hours;

    // Start is called before the first frame update
    void Start()
    {
        SetupStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableStatsPanel()
    {
        statsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void DisableStatsPanel()
    {
        statsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void EnableConfirmationPanel()
    {
        confirmationPanel.SetActive(true);
    }

    public void DisableConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void DeleteStats()
    {
        PlayerPrefs.DeleteAll();

        SetupStats();

        DisableConfirmationPanel();
    }

    void SetupStats()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        if (!PlayerPrefs.HasKey("HighBlock"))
        {
            PlayerPrefs.SetInt("HighBlock", 0);
        }
        if (!PlayerPrefs.HasKey("TimeSpent"))
        {
            PlayerPrefs.SetInt("TimeSpent", 0);
        }

        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        highBlock.text = "Highest Block: " + PlayerPrefs.GetInt("HighBlock");

        minutes = (PlayerPrefs.GetInt("TimeSpent") / 60);
        hours = minutes / 60;
        minutes = (minutes % 60);

        string minuteCounter;

        if (minutes < 10)
        {
            minuteCounter = "0" + minutes;
        }
        else
        {
            minuteCounter = minutes.ToString();
        }

        timeSpent.text = "Time Spent: " + hours + ":" + minuteCounter;
    }
}
