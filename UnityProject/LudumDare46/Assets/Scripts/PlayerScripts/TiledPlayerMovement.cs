using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator anim;

    public LayerMask stoppers;

    public GameObject aim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                anim.SetTrigger("Left");
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                anim.SetTrigger("Right");
            }
            else if(Input.GetAxisRaw("Vertical") == 1)
            {
                anim.SetTrigger("Up");
            }
            else if(Input.GetAxisRaw("Vertical") == -1)
            {
                anim.SetTrigger("Down");
            }
        }
        else
        {
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .085f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .4f, stoppers))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .4f, stoppers))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
        Aim();
    }

    void Aim()
    {
        if (Vector3.Distance(transform.position, movePoint.position) >= 1f)
        {
            aim.transform.position = movePoint.position;
        }
    }
   
}
