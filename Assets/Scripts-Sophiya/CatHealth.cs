using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    public int maxHealth = 5; //Max hälsa för Sirius
    private int currentHealth;
    public bool hasMagicShield = false; // Ifall katten har skölden

    void Start()
    {
        currentHealth = maxHealth; //starta med den max liv  
    }

    public void TakeDamage(int damage)
    {
        if (hasMagicShield)
        {
            hasMagicShield = false;
            Debug.Log("Skölden tog skadan");

        }
        else
        {

            currentHealth -= damage;
            Debug.Log("Katten tog skada! Liv kvar:" + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        Debug.Log("Katten är död");
    }
}

    

