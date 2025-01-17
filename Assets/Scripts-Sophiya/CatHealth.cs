using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximal h�lsa
    private int currentHealth;
    public GameObject bubbla; // Referens till bubbelsk�ldens spelobjekt
    private bool hasShield = false; // Om sk�lden �r aktiv

    void Start()
    {
        currentHealth = maxHealth; // Starta med maximal h�lsa
        bubbla.SetActive(false); // Sk�lden ska vara inaktiv vid start
    }

    void Update()
    {
        // Aktivera sk�lden n�r spelaren trycker p� "E"
        if (Input.GetKeyDown(KeyCode.E) && !hasShield)
        {
            ActivateShield();
        }
    }

    public void TakeDamage(int damage)
    {
        if (hasShield)
        {
            // Sk�lden �r aktiv, blockera skadan och ta bort sk�lden
            DeactivateShield();
            Debug.Log("Sk�lden tog skadan");
            return;
        }

        // Om sk�lden inte �r aktiv tar den skada
        currentHealth -= damage;
        Debug.Log("Katten tog skada! Nuvarande h�lsa: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ActivateShield()
    {
        hasShield = true;
        bubbla.SetActive(true); // Aktivera bubbelsk�lden
        Debug.Log("Sk�lden aktiverad!");
    }

    private void DeactivateShield()
    {
        hasShield = false;
        bubbla.SetActive(false); // Deaktivera bubbelsk�lden
        Debug.Log("Sk�lden inaktiverad!");
    }

    private void Die()
    {
        Debug.Log("Katten dog!");
        // L�gg till logik f�r att avsluta spelet eller �terst�lla scenen
    }
}


