using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeControl : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float maxDistance = 5f; // Maximum allowed stretch distance
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        // Update rope's visual representation
        lineRenderer.SetPosition(0, player1.position);
        lineRenderer.SetPosition(1, player2.position);

        // Enforce maximum distance
        float distance = Vector2.Distance(player1.position, player2.position);
        if (distance > maxDistance)
        {
            Vector2 direction = (player2.position - player1.position).normalized;
            Vector2 correction = direction * (distance - maxDistance);

            // Adjust player positions to enforce maximum distance
            player1.position += (Vector3)(-correction / 2);
            player2.position += (Vector3)(correction / 2);
        }
    }
}
