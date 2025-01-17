using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private bool isGrounded = true;
    SpriteRenderer sr;
    private Rigidbody2D rb;

    Ability ability;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.A)) horizontalInput = -1f;
        if (Input.GetKey(KeyCode.D)) horizontalInput = 1f;
        if (horizontalInput > 0f)
        {
            sr.flipX = false;
        }
        if (horizontalInput < 0f)
        {
            sr.flipX = true;
        }
        
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }
}
