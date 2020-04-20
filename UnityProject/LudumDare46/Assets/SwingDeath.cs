using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletDie());
    }

    IEnumerator BulletDie()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
