using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingbubbleSOL : MonoBehaviour
{
    public GameObject circlePrefab; // Prefab of the circle to spawn
    public float forwardForce = 5f; // Force applied forward when spawning the circle
    public float upwardForce = 2f;  // Force applied upward when spawning the circle
    public float lifespan = 15f;    // Time before the circle is destroyed
    public float cooldown;
    float lastbubble;

    private Vector2 lastMovementDirection = Vector2.right; // Tracks the last movement direction

    void Update()
    {
        // Track movement direction based on Player 1's horizontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            // Update the last movement direction based on input
            lastMovementDirection = new Vector2(horizontalInput, 0).normalized;
        }

        // Check if Player 1 presses the E key
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnCircle();
        }
    }

    void SpawnCircle()
    {
        // Spawn the circle prefab at Player 1's position
        GameObject circle = Instantiate(circlePrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component from the spawned circle
        Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply a forward force in the direction of the last movement, plus an upward force
            Vector2 spawnForce = (lastMovementDirection * forwardForce) + (Vector2.up * upwardForce);
            rb.AddForce(spawnForce, ForceMode2D.Impulse);
        }

        // Destroy the circle after the lifespan duration
        Destroy(circle, lifespan);
        if (Time.time - lastbubble < cooldown)
        {
            return;
        }
        lastbubble = Time.time;
    }
}