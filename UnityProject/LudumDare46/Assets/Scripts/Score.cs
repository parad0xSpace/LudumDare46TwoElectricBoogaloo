using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    void Start()
    {
        score = 0;
        scoreText.text = "" + score;
    }

    void Update()
    {
        score += DayNightCycle.dayCount * 100;
        scoreText.text = "" + score;
    }
}
