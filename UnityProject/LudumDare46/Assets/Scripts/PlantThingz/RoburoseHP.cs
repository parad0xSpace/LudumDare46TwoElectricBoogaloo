using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoburoseHP : MonoBehaviour
{
    public GameObject slider;
    public Slider hpSlider;
    public int hpStart = 6;
    int hp;
    float iFrames;
    public float iFramePrin = 4;
    public Animator plantKiller;
    bool IV;

    void Start()
    {
        iFrames = iFramePrin;
        hpSlider.maxValue = hpStart;
        slider.gameObject.SetActive(false);
        IV = false;
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

        if (IV && iFrames == iFramePrin)
        {
            iFrames -= Time.deltaTime;
        }

        if (iFrames < 0)
        {
            IV = false;
            iFrames = iFramePrin;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !IV)
        {
            hp--;
            hpSlider.value = hp;
            IV = true;
            if (hp < 1)
            {
                plantKiller.SetTrigger("Kill");
            }
        }
    }
}
