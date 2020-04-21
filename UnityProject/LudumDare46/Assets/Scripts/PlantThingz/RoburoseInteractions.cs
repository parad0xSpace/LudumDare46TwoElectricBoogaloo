using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoburoseInteractions : MonoBehaviour
{
    int day;
    public GameObject roseCanvas;
    bool dug;
    public bool rosePlanted;
    bool watered;
    public Animator anim;
    public bool grown;

    int s1;
    int s2;
    int s3;

    public GameObject slider;
    public Slider hpSlider;
    public int hpStart = 6;
    public static int hp;
    public Animator plantKiller;

    void Start()
    {
        day = DayNightCycle.dayCount;
        roseCanvas.gameObject.SetActive(false);
        dug = false;
        rosePlanted = false;
        watered = false;
        grown = false;

        hp = hpStart;
        hpSlider.maxValue = hpStart;
        slider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (DayNightCycle.dayCount > day)
        {
            Growth();
            day = DayNightCycle.dayCount;
        }

        if (hp < hpStart)
        {
            slider.gameObject.SetActive(true);
        }
        else
        {
            slider.gameObject.SetActive(false);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Interact();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            hp--;
            hpSlider.value = hp;
            if (hp < 1)
            {
                plantKiller.SetTrigger("Kill");
                grown = false;
                rosePlanted = false;
                dug = false;
                watered = false;
            }
        }
    }

    void Interact()
    {
        if (EquipTools.trowelEquip)
        {
            if (!dug)
            {
                if (!watered)
                {
                    anim.SetTrigger("DryDig");
                    dug = true;
                }
                else
                {
                    anim.SetTrigger("WetDig");
                    dug = true;
                }
            }
            if (dug && !rosePlanted)
            {
                s1 = DayNightCycle.dayCount;
                s2 = s1 + 1;
                s3 = s2 + 1;
                rosePlanted = true;
                if (!watered)
                {
                    anim.SetTrigger("DryStage1");
                }
                else
                {
                    anim.SetTrigger("WetStage1");
                }
            }
        }

        if (EquipTools.waterEquip && !watered)
        {
            if (DayNightCycle.dayCount == s1 && rosePlanted)
            {
                anim.SetTrigger("WetStage1");
                watered = true;
            }
            else if (DayNightCycle.dayCount == s2 && rosePlanted)
            {
                anim.SetTrigger("WetStage2");
                watered = true;
            }
            else if (DayNightCycle.dayCount >= s3 && rosePlanted)
            {
                anim.SetTrigger("WetStage3");
                watered = true;
            }
            else if (dug)
            {
                anim.SetTrigger("WetDig");
                watered = true;
            }
            else
            {
                anim.SetTrigger("Wet");
                watered = true;
            }
        }

        if (EquipTools.fertilizerEquip && hp < hpStart)
        {
            hp++;
        }

        if (EquipTools.sickleEquip && DayNightCycle.dayCount >= s3 && rosePlanted)
        {
            roseCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        roseCanvas.gameObject.SetActive(false);
    }

    void Growth()
    {
        if(DayNightCycle.dayCount == s2 && watered)
        {
            anim.SetTrigger("DryStage2");
        }
        else if (DayNightCycle.dayCount >= s3 && watered)
        {
            grown = true;
            anim.SetTrigger("DryStage3");
        }
        else
        {
            anim.SetTrigger("Dry");
        }
        watered = false;
    }

    public void YesHarvest()
    {
        roseCanvas.gameObject.SetActive(false);
        dug = false;
        rosePlanted = false;
        grown = false;
        Score.score += 50;
        if (watered)
        {
            anim.SetTrigger("Wet");
        }
        else
        {
            anim.SetTrigger("Dry");
        }
    }
}
