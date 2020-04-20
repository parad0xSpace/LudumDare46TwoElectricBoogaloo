using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeloxBelleInteractions : MonoBehaviour
{
    int day;
    public GameObject belleCanvas;
    bool dug;
    public static bool bellePlanted;
    bool watered;
    public static bool grown;
    public Animator anim;

    int s1;
    int s2;
    int s3;
    int s4;

    void Start()
    {
        day = DayNightCycle.dayCount;
        belleCanvas.gameObject.SetActive(false);
        dug = false;
        bellePlanted = false;
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
            if (dug && !bellePlanted)
            {
                s1 = DayNightCycle.dayCount;
                s2 = s1 + 1;
                s3 = s2 + 1;
                s4 = s3 + 1;
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
            if (DayNightCycle.dayCount == s1 && bellePlanted)
            {
                anim.SetTrigger("WetStage1");
                watered = true;
            }
            else if (DayNightCycle.dayCount == s2 && bellePlanted)
            {
                anim.SetTrigger("WetStage2");
                watered = true;
            }
            else if (DayNightCycle.dayCount == s3 && bellePlanted)
            {
                anim.SetTrigger("WetStage3");
                watered = true;
            }
            else if (DayNightCycle.dayCount >= s4 && bellePlanted)
            {
                anim.SetTrigger("WetStage4");
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

        if (EquipTools.fertilizerEquip && VeloxBelleHP.hp < 5)
        {
            VeloxBelleHP.hp++;
        }

        if (EquipTools.sickleEquip && DayNightCycle.dayCount >= s3)
        {
            Score.score += 50;
            if (watered)
            {
                anim.SetTrigger("Wet");
                grown = false;
                dug = false;
                bellePlanted = false;
            }
            else
            {
                anim.SetTrigger("Dry");
                grown = false;
                dug = false;
                bellePlanted = false;
            }
        }
    }

    void Growth()
    {
        if (DayNightCycle.dayCount == s2 && bellePlanted && watered)
        {
            anim.SetTrigger("DryStage2");
            watered = false;
        }
        else if (DayNightCycle.dayCount == s3 && bellePlanted && watered)
        {
            anim.SetTrigger("DryStage3");
            watered = false;
        }
        else if(DayNightCycle.dayCount >= s4 && bellePlanted && watered)
        {
            anim.SetTrigger("DryStage4");
            watered = false;
            grown = true;
        }
        else
        {
            anim.SetTrigger("Dry");
        }
    }
}
