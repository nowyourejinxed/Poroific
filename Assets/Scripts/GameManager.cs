using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int killCount = 0;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI currentScore;

    public void Start()
    {
        UpdateHighScore();
        currentScore.text = $"Current Score: {killCount}";
    }

    public void IncreaseScore()
    {
        killCount++;
        //increment ui
        currentScore.text = $"Current Score: {killCount}";
        CheckHighScore();
    }

    public void CheckHighScore()
    {
        if (killCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            //saves locally
            PlayerPrefs.SetInt("HighScore", killCount);
            UpdateHighScore();
        }
    }

    public void UpdateHighScore()
    {
        highScore.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
