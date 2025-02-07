using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TripleShoot : MonoBehaviour
{
    public GameObject ballPrefab;    // Prefab f�r bollen
    public float ballSpeed = 10f;   // Hastighet p� bollarna
    public float spreadAngle = 15f; // Vinkel f�r spridning av bollarna
    public float lifespan = 5f;
    float lastball;
    public float cooldown = 5f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // N�r E-knappen trycks
        {
            ShootBalls();
        }
    }

    private void ShootBalls()
    {
        // Skjut rakt fram
        ShootInDirection(Vector2.right);

        // Skjut snett upp�t
        ShootInDirection(Quaternion.Euler(0, 0, spreadAngle) * Vector2.right);

        // Skjut snett ned�t
        ShootInDirection(Quaternion.Euler(0, 0, -spreadAngle) * Vector2.right);
    }

    private void ShootInDirection(Vector2 direction)
    {
        // Skapa bollen vid spelarens position
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Ge bollen en r�relse
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * ballSpeed;
        }
        Destroy(ball, lifespan);
        if (Time.time - lastball < cooldown)
        {
            return;
        }
        lastball = Time.time;
    }
}
    


