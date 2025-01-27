using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximal hälsa
    private int currentHealth;
    public GameObject bubbla; // Referens till bubbelsköldens spelobjekt
    private bool hasShield = false; // Om skölden är aktiv

    void Start()
    {
        currentHealth = maxHealth; // Starta med maximal hälsa
        bubbla.SetActive(false); // Skölden ska vara inaktiv vid start
    }

    void Update()
    {
        // Aktivera skölden när spelaren trycker på "E"
        if (Input.GetKeyDown(KeyCode.E) && !hasShield)
        {
            ActivateShield();
        }
    }

    public void TakeDamage(int damage)
    {
        if (hasShield)
        {
            // Skölden är aktiv, blockera skadan och ta bort skölden
            DeactivateShield();
            Debug.Log("Skölden tog skadan");
            return;
        }

        // Om skölden inte är aktiv tar den skada
        currentHealth -= damage;
        Debug.Log("Katten tog skada! Nuvarande hälsa: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ActivateShield()
    {
        hasShield = true;
        bubbla.SetActive(true); // Aktivera bubbelskölden
        Debug.Log("Skölden aktiverad!");
    }

    private void DeactivateShield()
    {
        hasShield = false;
        bubbla.SetActive(false); // Deaktivera bubbelskölden
        Debug.Log("Skölden inaktiverad!");
    }

    private void Die()
    {
        Debug.Log("Katten dog!");
        // Lägg till logik för att avsluta spelet eller återställa scenen
    }
}


