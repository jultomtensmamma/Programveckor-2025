using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // Speed of left and right movement
    public float jumpForce = 7f; // Force of the jump
    private bool isGrounded = true; // Check if the player is on the ground

    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input (-1 for A, 1 for D)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement in FixedUpdate for smoother physics
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        // Apply upward force for jumping
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
