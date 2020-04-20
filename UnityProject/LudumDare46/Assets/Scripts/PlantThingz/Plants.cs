using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    int day;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    public GameObject p9;

    public GameObject p1Canvas;
    public GameObject p2Canvas;
    public GameObject p3Canvas;
    public GameObject p4Canvas;
    public GameObject p5Canvas;
    public GameObject p6Canvas;
    public GameObject p7Canvas;
    public GameObject p8Canvas;
    public GameObject p9Canvas;

    bool p1Dug;
    bool p2Dug;
    bool p3Dug;
    bool p4Dug;
    bool p5Dug;
    bool p6Dug;
    bool p7Dug;
    bool p8Dug;
    bool p9Dug;

    bool p1Planted;
    bool p2Planted;
    bool p3Planted;
    bool p4Planted;
    bool p5Planted;
    bool p6Planted;
    bool p7Planted;
    bool p8Planted;
    bool p9Planted;

    bool p1Watered;
    bool p2Watered;
    bool p3Watered;
    bool p4Watered;
    bool p5Watered;
    bool p6Watered;
    bool p7Watered;
    bool p8Watered;
    bool p9Watered;

    int p1S1;
    int p1S2;
    int p1S3;
    int p1S4;

    void Start()
    {
        day = DayNightCycle.dayCount;
        p1Canvas.gameObject.SetActive(false);
        p2Canvas.gameObject.SetActive(false);
        p3Canvas.gameObject.SetActive(false);
        p4Canvas.gameObject.SetActive(false);
        p5Canvas.gameObject.SetActive(false);
        p6Canvas.gameObject.SetActive(false);
        p7Canvas.gameObject.SetActive(false);
        p8Canvas.gameObject.SetActive(false);
        p9Canvas.gameObject.SetActive(false);

        p1Dug = false;
        p2Dug = false;
        p3Dug = false;
        p4Dug = false;
        p5Dug = false;
        p6Dug = false;
        p7Dug = false;
        p8Dug = false;
        p9Dug = false;

        p1Planted = false;
        p2Planted = false;
        p3Planted = false;
        p4Planted = false;
        p5Planted = false;
        p6Planted = false;
        p7Planted = false;
        p8Planted = false;
        p9Planted = false;

        p1Watered = false;
        p2Watered = false;
        p3Watered = false;
        p4Watered = false;
        p5Watered = false;
        p6Watered = false;
        p7Watered = false;
        p8Watered = false;
        p9Watered = false;
    }

    void Update()
    {
        if(DayNightCycle.dayCount > day)
        {
            Growth();
            day = DayNightCycle.dayCount;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "p1" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter1();
        }
        else if (collision.gameObject.tag == "p2" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter2();
        }
        else if (collision.gameObject.tag == "p3" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter3();
        }
        else if (collision.gameObject.tag == "p4" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter4();
        }
        else if (collision.gameObject.tag == "p5" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter5();
        }
        else if (collision.gameObject.tag == "p6" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter6();
        }
        else if (collision.gameObject.tag == "p7" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter7();
        }
        else if (collision.gameObject.tag == "p8" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter8();
        }
        else if (collision.gameObject.tag == "p9" && Input.GetKeyDown(KeyCode.E) && !DayNightCycle.isNight)
        {
            Planter9();
        }
    }

    void Planter1()
    {
        if(EquipTools.trowelEquip)
        {
            if(!p1Dug)
            {
                if (!p1Watered)
                {
                    p1.gameObject.GetComponent<Animator>().SetTrigger("DryDig");
                    p1Dug = true;
                }
                else
                {
                    p1.gameObject.GetComponent<Animator>().SetTrigger("WetDig");
                    p1Dug = true;
                }
            }
            if(p1Dug && !p1Planted)
            {
                p1S1 = DayNightCycle.dayCount;
                p1S2 = p1S1 + 1;
                p1S3 = p1S2 + 1;
                p1S4 = p1S3 + 1;
                if(!p1Watered)
                {
                    p1.gameObject.GetComponent<Animator>().SetTrigger("DryStage1");
                }
                else
                {
                    p1.gameObject.GetComponent<Animator>().SetTrigger("WetStage1");
                }
            }
        }

        if(EquipTools.waterEquip && !p1Watered)
        {
            if(DayNightCycle.dayCount == p1S1)
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("WetStage1");
                p1Watered = true;
            }
            else if (DayNightCycle.dayCount == p1S2)
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("WetStage2");
            }
            else if (DayNightCycle.dayCount == p1S3)
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("WetStage3");
            }
            else if (DayNightCycle.dayCount >= p1S4)
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("WetStage4");
            }
            else if (p1Dug)
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("WetDig");
            }
            else
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("Wet");
            }
        }

        if(EquipTools.sickleEquip && DayNightCycle.dayCount == p1S4)
        {
            Score.score += 50;
            if(p1Watered)
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("Wet");
            }
            else
            {
                p1.gameObject.GetComponent<Animator>().SetTrigger("Dry");
            }
        }
    }

    void Planter2()
    {

    }

    void Planter3()
    {

    }

    void Planter4()
    {

    }

    void Planter5()
    {

    }

    void Planter6()
    {

    }

    void Planter7()
    {

    }

    void Planter8()
    {

    }

    void Planter9()
    {

    }

    void Growth()
    {

    }
}
