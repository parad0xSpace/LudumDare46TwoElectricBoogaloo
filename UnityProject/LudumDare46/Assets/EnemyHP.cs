using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int hp = 4;
    bool grownBuff;
    private bool thing;

    void OnTriggerEnter2D(Collider2D collision)
    {
        hp--;

        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
