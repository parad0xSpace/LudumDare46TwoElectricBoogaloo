using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTools : MonoBehaviour
{
    public GameObject wateringCan;
    public GameObject trowel;
    public GameObject fertilizer;
    public GameObject sickle;

    public GameObject wateringCanHUD;
    public GameObject trowelHUD;
    public GameObject fertilizerHUD;
    public GameObject sickleHUD;

    public static bool waterEquip;
    public static bool trowelEquip;
    public static bool fertilizerEquip;
    public static bool sickleEquip;

    void Start()
    {
        wateringCan.gameObject.SetActive(true);
        trowel.gameObject.SetActive(true);
        fertilizer.gameObject.SetActive(true);
        sickle.gameObject.SetActive(true);

        wateringCanHUD.gameObject.SetActive(false);
        trowelHUD.gameObject.SetActive(false);
        fertilizerHUD.gameObject.SetActive(false);
        sickleHUD.gameObject.SetActive(false);

        waterEquip = false;
        trowelEquip = false;
        fertilizerEquip = false;
        sickleEquip = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("huzzah!");
        if(collision.gameObject.tag == "wateringcan" && !waterEquip && !DayNightCycle.isNight)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                wateringCan.gameObject.SetActive(false);
                trowel.gameObject.SetActive(true);
                fertilizer.gameObject.SetActive(true);
                sickle.gameObject.SetActive(true);

                wateringCanHUD.gameObject.SetActive(true);
                trowelHUD.gameObject.SetActive(false);
                fertilizerHUD.gameObject.SetActive(false);
                sickleHUD.gameObject.SetActive(false);

                waterEquip = true;
                trowelEquip = false;
                fertilizerEquip = false;
                sickleEquip = false;
                Debug.Log(waterEquip);
            }
        }
        if (collision.gameObject.tag == "trowel" && !trowelEquip && !DayNightCycle.isNight)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                wateringCan.gameObject.SetActive(true);
                trowel.gameObject.SetActive(false);
                fertilizer.gameObject.SetActive(true);
                sickle.gameObject.SetActive(true);

                wateringCanHUD.gameObject.SetActive(false);
                trowelHUD.gameObject.SetActive(true);
                fertilizerHUD.gameObject.SetActive(false);
                sickleHUD.gameObject.SetActive(false);

                waterEquip = false;
                trowelEquip = true;
                fertilizerEquip = false;
                sickleEquip = false;
                Debug.Log(trowelEquip);
            }
        }
        if (collision.gameObject.tag == "fertilizer" && !fertilizerEquip && !DayNightCycle.isNight)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                wateringCan.gameObject.SetActive(true);
                trowel.gameObject.SetActive(true);
                fertilizer.gameObject.SetActive(false);
                sickle.gameObject.SetActive(true);

                wateringCanHUD.gameObject.SetActive(false);
                trowelHUD.gameObject.SetActive(false);
                fertilizerHUD.gameObject.SetActive(true);
                sickleHUD.gameObject.SetActive(false);

                waterEquip = false;
                trowelEquip = false;
                fertilizerEquip = true;
                sickleEquip = false;
                Debug.Log(fertilizerEquip);
            }
        }
        if (collision.gameObject.tag == "sickle" && !sickleEquip)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                wateringCan.gameObject.SetActive(true);
                trowel.gameObject.SetActive(true);
                fertilizer.gameObject.SetActive(true);
                sickle.gameObject.SetActive(false);

                wateringCanHUD.gameObject.SetActive(false);
                trowelHUD.gameObject.SetActive(false);
                fertilizerHUD.gameObject.SetActive(false);
                sickleHUD.gameObject.SetActive(true);

                waterEquip = false;
                trowelEquip = false;
                fertilizerEquip = false;
                sickleEquip = true;
                Debug.Log(sickleEquip);
            }
        }
    }
}
