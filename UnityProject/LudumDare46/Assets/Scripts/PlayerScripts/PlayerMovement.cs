using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator controller;

    

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x == 0 && movement.y == 1)
        {
            controller.SetTrigger("Up");
        }
        else if (movement.x == 0 && movement.y == -1)
        {
            controller.SetTrigger("Down");
        }
        else if (movement.x == 1 && movement.y == 0)
        {
            controller.SetTrigger("Right");
        }
        else if (movement.x == -1 && movement.y == 0)
        {
            controller.SetTrigger("Left");
        }
        else if(movement.x == 0 && movement.y == 0)
        {
            controller.SetTrigger("Idle");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
