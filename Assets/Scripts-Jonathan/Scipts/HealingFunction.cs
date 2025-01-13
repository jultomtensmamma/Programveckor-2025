using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFunction : MonoBehaviour
{
    public float healingAmount = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);

        // Check if the collided object has a HealthScript component
        HealthScript healthScript = other.gameObject.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            // Heal the player
            healthScript.health = Mathf.Clamp(healthScript.health + healingAmount, 0, healthScript.maxhealth);

            // Destroy the healing bubble
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No HealthScript found on the collided object.");
        }
    }
}

