using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player2DController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float walkSpeed = 40.0F;

    [SerializeField]
    [Range(0.1F, 1F)]
    float smoothSpeed = 0.15F;

    [SerializeField]
    bool isFacingRight = true;

    [Header("Jump")]
    [SerializeField]
    float jumpForce = 140.0F;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    float jumpGraceTime = 0.25F;

    [SerializeField]
    float fallMultiplier = 15.0F;

    Rigidbody2D rb;

    Vector2 gravity;
    Vector2 velocityZero = Vector2.zero;

    float inputX;
    float lastTimeJumpPreseed;

    bool isMoving;
    bool isJumpPressed;

    [Header("Animation")]
    [SerializeField]
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = -Physics2D.gravity;
  
    }
    void Update()
    {
        HandleInputs();
    }
    private void FixedUpdate()
    {
        HandleJump();
        HandleMove();
        HandleFlipX();
    }

    void HandleInputs()
    {
        inputX = Input.GetAxisRaw("Horizontal") * walkSpeed;
        isMoving = inputX != 0.0F;

        isJumpPressed = Input.GetButtonDown("Jump");
        if (isJumpPressed)
        {
            lastTimeJumpPreseed = Time.time;
        }
    }

    void HandleMove()
    {
        float velocityX = inputX * Time.fixedDeltaTime;
        animator.SetFloat("speed", MathF.Abs(velocityX));

        Vector2 direction = new Vector2(velocityX, rb.velocity.y);

        rb.velocity = Vector2.SmoothDamp(rb.velocity, direction, ref velocityZero, smoothSpeed);

    }

    void HandleFlipX()
    {
        if (isMoving)
        {
            bool facingRight = inputX > 0.0F;
            if (isFacingRight != facingRight)
            {
                isFacingRight = facingRight;
                transform.Rotate(0.0F, 180.0F, 0.0F);
            }
        }
    }

    void HandleJump()
    {
        if (lastTimeJumpPreseed > 0.0F && Time.time - lastTimeJumpPreseed <= jumpGraceTime)
        {
            isJumpPressed = true;
        }
        else
        {
            lastTimeJumpPreseed = 0.0F;
        }

        if (isJumpPressed && IsGrounded())
        {
            AudioManager.Instance.PlaySFX("Salto");

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
