using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingbubbleSOL : MonoBehaviour
{
    public GameObject circlePrefab; 
    public float forwardForce = 5f; 
    public float upwardForce = 2f; 
    public float lifespan = 15f;   
    public float cooldown = 5f;
    public float spawnDistance = 1.5f;
    float lastbubble;
    private float lastSpawnTime = -Mathf.Infinity;

    private Vector2 lastMovementDirection = Vector2.right; 

    void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
           
            lastMovementDirection = new Vector2(horizontalInput, 0).normalized;
        }


        if (Input.GetKeyDown(KeyCode.E) && Time.time >= lastSpawnTime + cooldown)
        {
            SpawnCircle();
            lastSpawnTime = Time.time; 
        }
    }

    void SpawnCircle()
    {
        
        Vector2 spawnPosition = (Vector2)transform.position + lastMovementDirection * spawnDistance;

        
        GameObject circle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);

        
        Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            
            Vector2 spawnForce = (lastMovementDirection * forwardForce) + (Vector2.up * upwardForce);
            rb.AddForce(spawnForce, ForceMode2D.Impulse);
        }

        
        Destroy(circle, lifespan);
        if (Time.time - lastbubble < cooldown)
        {
            return;
        }
        lastbubble = Time.time;
    }
}