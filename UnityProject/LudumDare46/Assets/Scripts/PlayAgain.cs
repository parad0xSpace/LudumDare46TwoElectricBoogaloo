using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
    public Text scoreText;
    int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
