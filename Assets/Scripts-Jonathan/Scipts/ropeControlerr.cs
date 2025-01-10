using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeControlerr : MonoBehaviour
{
    
    public Transform player1;      // Player 1's Transform
    public Transform player2;      // Player 2's Transform
    public float maxDistance = 5f; // Maximum allowed rope stretch distance
    public float pullForce = 10f;  // Force to pull players back when exceeding maxDistance
    private LineRenderer lineRenderer;

    void Start()
    {
        // Initialize the LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        // Update the rope's visual representation
        lineRenderer.SetPosition(0, player1.position);
        lineRenderer.SetPosition(1, player2.position);

        // Calculate the distance between the two players
        float distance = Vector2.Distance(player1.position, player2.position);

        // If the distance exceeds the maximum allowed distance
        if (distance > maxDistance)
        {
            // Calculate the direction from player1 to player2
            Vector2 direction = (player2.position - player1.position).normalized;

            // Apply forces to pull the players back towards each other
            Rigidbody2D rb1 = player1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = player2.GetComponent<Rigidbody2D>();

            if (rb1 != null && rb2 != null)
            {
                // Apply forces proportional to the excess distance
                float excessDistance = distance - maxDistance;
                Vector2 correctionForce = direction * (excessDistance * pullForce);

                rb1.AddForce(correctionForce);
                rb2.AddForce(-correctionForce);
            }
        }
    }
}