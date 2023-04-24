using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollController : MonoBehaviour
{
    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float speed;

    [SerializeField]
    float distance;

    [SerializeField]
    bool isFacingRight = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

        if (!raycastHit2D)
        {
            FlipX();
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void FlipX()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0.0F, 180.0F, 0.0F);

        speed *= -1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * distance);
    }
}
