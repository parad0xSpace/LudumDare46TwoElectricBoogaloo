using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckButton : MonoBehaviour
{
    public Transform startPos;
    public GameObject movePoint;
    public GameObject player;
    
    void Start()
    {
        startPos.parent = null;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            movePoint.transform.position = startPos.position;
            movePoint.transform.rotation = startPos.rotation;
            player.transform.position = startPos.position;
            player.transform.rotation = startPos.rotation;
        }
    }
}
