using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumperController : MonoBehaviour
{
    [SerializeField]
    float minWaitTime;

    [SerializeField]
    float maxWaitTime;

    [SerializeField]
    float jumpForce = 140.0F;

    [SerializeField]
    float fallMultiplier = 15.0F;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask groundMask;

    Vector2 gravity;

    Rigidbody2D rb;

    float currenTime;

    float randomNumer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = -Physics2D.gravity;
    }

    void Update()
    {
        currenTime = Time.deltaTime;
        if (currenTime >= minWaitTime && currenTime <= maxWaitTime)
        {
            HandleJump();
        }
    }

    private void FixedUpdate()
    {
        currenTime = Time.deltaTime;
        if (currenTime >= minWaitTime && currenTime <= maxWaitTime)
        {
            HandleJump();
        }
    }

    void HandleJump()
    {
        if (IsGrounded())
        {
            rb.velocity += Vector2.up * jumpForce * Time.fixedDeltaTime;
            return;
        }

        if (rb.velocity.y < -0.1F)
        {
            rb.velocity -= gravity * fallMultiplier * Time.fixedDeltaTime;
        }
    }

    bool IsGrounded()
    {
        return
            Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.63F, 0.04F),
                CapsuleDirection2D.Horizontal, 0.0F, groundMask);
    }
}
