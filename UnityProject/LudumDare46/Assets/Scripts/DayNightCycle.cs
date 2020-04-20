using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public static bool isDay = false;
    public static bool isEvening = false;
    public static bool isNight = false;

    public Text timeText;
    public Text daysText;

    public static int dayCount;

    void Start()
    {
        isDay = false;
        isEvening = false;
        isNight = false;
        DayStart();
        dayCount = 1;
        daysText.text = "" + dayCount;
    }

    void DayStart()
    {
        isDay = true;
        timeText.text = "Day";
        StartCoroutine(DayTimer());
    }

    void EveningStart()
    {
        isEvening = true;
        timeText.text = "Evening";
        StartCoroutine(EveningTimer());
    }

    void NightStart()
    {
        isNight = true;
        timeText.text = "Night";
        StartCoroutine(NightTimer());
    }

    IEnumerator DayTimer()
    {
        Debug.Log("Day");
        yield return new WaitForSeconds(90);
        isDay = false;
        EveningStart();
    }

    IEnumerator EveningTimer()
    {
        Debug.Log("Evening");
        yield return new WaitForSeconds(30);
        isEvening = false;
        NightStart();
    }

    IEnumerator NightTimer()
    {
        Debug.Log("Night");
        yield return new WaitForSeconds(60);
        isNight = false;
        DayStart();
        dayCount++;
        daysText.text = "" + dayCount;
    }
}
