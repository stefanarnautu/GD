using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private float jumpForce = 10f;
    private bool canJump = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 1f && canJump)
        {
 
            bool isBelowBall = false;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.point.y < transform.position.y)
                {
                    isBelowBall = true;
                    break;
                }
            }

            if (isBelowBall)
            {
                Vector2 jumpDirection = collision.GetContact(0).normal;
                rb.AddForce(jumpDirection.normalized * jumpForce, ForceMode2D.Impulse);
                canJump = false;
                Invoke(nameof(ResetJump), 0.5f);
            }
        }
    }

    private void ResetJump()
    {
        canJump = true;
    }
}
