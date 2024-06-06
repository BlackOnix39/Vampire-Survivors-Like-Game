using System.Collections;
using System.Collections.Generic;
using Terresquall;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;

    Rigidbody2D rb;
    PlayerStats player;

    void Start()
    {
        player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    
    void Update()
    {
        InputManagment();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagment ()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        float moveX, moveY;
        if(VirtualJoystick.CountActiveInstances() > 0)
        {
            moveX = VirtualJoystick.GetAxisRaw("Horizontal");
            moveY = VirtualJoystick.GetAxisRaw("Vertical");
        }
        else
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    void Move()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        rb.velocity = new Vector2 (moveDir.x * player.CurrentMoveSpeed, moveDir.y * player.CurrentMoveSpeed);
    }
}
