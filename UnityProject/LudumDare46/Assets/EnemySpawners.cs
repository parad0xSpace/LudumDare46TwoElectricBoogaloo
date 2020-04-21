using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    public GameObject enemies;
    public Transform spawner;
    bool timerDone = true;

    private void Start()
    {
        timerDone = true;
    }

    void Update()
    {
        if(DayNightCycle.isNight && timerDone)
        {
            StartCoroutine(TimerCount());
            Debug.Log("foo");
        }

        if(DayNightCycle.isDay)
        {
            DestroyAllObjects();
        }
    }

    IEnumerator TimerCount()
    {
        timerDone = false;
        yield return new WaitForSeconds(5);
        Debug.Log("timer done");
        SpawnEnemies();
        timerDone = true;
    }

    void SpawnEnemies()
    {
        int e = Random.Range(0, 10);
        Debug.Log(e);
        if (e <= 3)
        {
            SpawnGameObject(enemies, spawner, DayNightCycle.dayCount);
        }
        else
        {
            return;
        }
    }

    void SpawnGameObject(GameObject obj, Transform parent, int times)
    {
        for (int i = 0; i < times; i++)
        {
            Instantiate(obj, parent);
            Debug.Log("victoire");
        }
    }

    void DestroyAllObjects()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}


