using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemericInteractions : MonoBehaviour
{
    int day;
    public GameObject temericCanvas;
    bool dug;
    public static bool temericPlanted;
    bool watered;
    public static bool grown;
    public Animator anim;

    int s1;
    int s2;
    int s3;
    int s4;
    int s5;

    void Start()
    {
        day = DayNightCycle.dayCount;
        temericCanvas.gameObject.SetActive(false);
        dug = false;
        temericPlanted = false;
        watered = false;
        grown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DayNightCycle.dayCount > day)
        {
            Growth();
            day = DayNightCycle.dayCount;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Interact();
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
            if (dug && !temericPlanted)
            {
                s1 = DayNightCycle.dayCount;
                s2 = s1 + 1;
                s3 = s2 + 1;
                s4 = s3 + 1;
                s5 = s4 + 1;
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
            if (DayNightCycle.dayCount == s1 && temericPlanted)
            {
                anim.SetTrigger("WetStage1");
                watered = true;
            }
            else if (DayNightCycle.dayCount == s2 && temericPlanted)
            {
                anim.SetTrigger("WetStage2");
                watered = true;
            }
            else if (DayNightCycle.dayCount == s3 && temericPlanted)
            {
                anim.SetTrigger("WetStage3");
                watered = true;
            }
            else if (DayNightCycle.dayCount == s4 && temericPlanted)
            {
                anim.SetTrigger("WetStage4");
                watered = true;
            }
            else if (DayNightCycle.dayCount >= s5 && temericPlanted)
            {
                anim.SetTrigger("WetStage5");
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

        if (EquipTools.fertilizerEquip && TemericHP.hp < 5)
        {
            TemericHP.hp++;
        }

        if (EquipTools.sickleEquip && DayNightCycle.dayCount >= s3 && temericPlanted)
        {
            Score.score += 50;
            if (watered)
            {
                anim.SetTrigger("Wet");
                grown = false;
                dug = false;
                temericPlanted = false;
            }
            else
            {
                anim.SetTrigger("Dry");
                grown = false;
                dug = false;
                temericPlanted = false;
            }
        }
    }

    void Growth()
    {
        if (DayNightCycle.dayCount == s2 && temericPlanted && watered)
        {
            anim.SetTrigger("DryStage2");
            watered = false;
        }
        else if (DayNightCycle.dayCount == s3 && temericPlanted && watered)
        {
            anim.SetTrigger("DryStage3");
            watered = false;
        }
        else if(DayNightCycle.dayCount == s4 && temericPlanted && watered)
        {
            anim.SetTrigger("DryStage4");
            watered = false;
        }
        else if (DayNightCycle.dayCount >= s5 && temericPlanted && watered)
        {
            anim.SetTrigger("DryStage5");
            watered = false;
            grown = true;
        }
        else
        {
            anim.SetTrigger("Dry");
        }
    }
}
