using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiende : MonoBehaviour
{
    public int maxHealth = 100; // Fiendens maximala hälsa
    private int currentHealth; // Fiendens nuvarande hälsa

    void Start()
    {
        // Sätt nuvarande hälsa till maxhälsa vid start
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Minska fiendens hälsa med skadevärdet
        currentHealth -= damage;

        // Visa fiendens återstående hälsa (valfritt)
        Debug.Log($"Fienden tog {damage} skada. Hälsa kvar: {currentHealth}");

        // Kontrollera om fienden är död
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Kör eventuella dödslogik här, t.ex. spela en animation
        Debug.Log("Fienden är död!");

        // Förstöra fienden
        Destroy(gameObject);
    }
}