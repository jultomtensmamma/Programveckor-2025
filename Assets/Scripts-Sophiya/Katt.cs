using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katt : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 6f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.A)) moveDirection = -0.5;
        if (Input.GetKey(KeyCode.D)) moveDirection = 0.5f;

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

}
