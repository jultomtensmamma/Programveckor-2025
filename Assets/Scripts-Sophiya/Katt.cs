using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katt : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 4f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveDirection = 1f;
        if (Input.GetKey(KeyCode.A)) moveDirection = -2f;
        if (Input.GetKey(KeyCode.D)) moveDirection = -2f;

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
