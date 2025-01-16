using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiende : MonoBehaviour
{
    public int maxHealth = 100; // Fiendens maximala h�lsa
    private int currentHealth; // Fiendens nuvarande h�lsa

    void Start()
    {
        // S�tt nuvarande h�lsa till maxh�lsa vid start
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Minska fiendens h�lsa med skadev�rdet
        currentHealth -= damage;

        // Visa fiendens �terst�ende h�lsa (valfritt)
        Debug.Log($"Fienden tog {damage} skada. H�lsa kvar: {currentHealth}");

        // Kontrollera om fienden �r d�d
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // K�r eventuella d�dslogik h�r, t.ex. spela en animation
        Debug.Log("Fienden �r d�d!");

        // F�rst�ra fienden
        Destroy(gameObject);
    }
}