using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    int day;

    void Start()
    {
        day = DayNightCycle.dayCount;
        score = 0;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }

    void Update()
    {
        if (DayNightCycle.dayCount > day)
        {
            score += DayNightCycle.dayCount * 100;
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("Score", score);
            day = DayNightCycle.dayCount;
        }
    }
}
