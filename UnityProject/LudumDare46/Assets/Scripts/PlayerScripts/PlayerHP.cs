using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject slider;
    public Slider hpSlider;
    public int hpStart = 10;
    public static int hp;

    void Start()
    {
        hp = hpStart;
        hpSlider.maxValue = hpStart;
        slider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (hp < hpStart)
        {
            slider.gameObject.SetActive(true);
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 1;
            hpSlider.value = hp;
            if (hp < 1)
            {
                SceneManager.LoadScene("HighScore");
            }
        }
    }
}
