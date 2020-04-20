using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioSource dayTheme;
    public AudioSource nightTheme;

    bool dayPlay;
    bool nightPlay;
    
    void Start()
    {
        dayTheme.Play();
        nightTheme.Stop();
        dayPlay = true;
        nightPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(DayNightCycle.isDay && !dayPlay)
        {
            nightTheme.Stop();
            dayTheme.Play();
            dayPlay = true;
            nightPlay = false;
        }
        if(DayNightCycle.isNight && !nightPlay)
        {
            dayTheme.Stop();
            nightTheme.Play();
            nightPlay = true;
            dayPlay = false;
        }
    }
}
