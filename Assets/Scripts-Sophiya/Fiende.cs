using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiende : MonoBehaviour
{
    public int maxHealth = 100; // Fiendens maximala hälsa
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Fienden tog {damage} skada. Hälsa kvar: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Fienden är död!");
        Destroy(gameObject);
    }
}