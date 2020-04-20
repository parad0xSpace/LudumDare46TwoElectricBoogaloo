using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject swingPrefab;

    public float deathTimerP = 1f;
    float deathTimer;

    void Start()
    {
        deathTimer = deathTimerP;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && EquipTools.sickleEquip)
        {
            Swing();
        }
    }

    void Swing()
    {
        Instantiate(swingPrefab, firePoint.position, firePoint.rotation);
    }
}
