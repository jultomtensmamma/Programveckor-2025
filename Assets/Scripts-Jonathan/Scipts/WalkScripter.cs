using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class MoveLeftRight : MonoBehaviour
    {
        public float speed = 5f; // Movement speed
        public float jumpForce = 5f; // Jump force
        public bool isGrounded = true; // Check if player is on the ground

        private Rigidbody2D rb;

        void Start()
        {
            // Get the Rigidbody component
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Get horizontal input (-1 for left, 1 for right, 0 for no input)
            float horizontalInput = Input.GetAxis("Horizontal");

            // Calculate movement
            Vector3 movement = new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;

            // Apply movement
            transform.Translate(movement);

            // Check for jump input
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
        }

        void Jump()
        {
            // Apply upward force for jump
            rb.AddForce(Vector3.up * jumpForce, (ForceMode2D)ForceMode.Impulse);
            isGrounded = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Check if the object is touching the ground
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }

