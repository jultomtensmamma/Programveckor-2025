using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealth : MonoBehaviour
{
    public int maxHealth = 5; //Max h�lsa f�r Sirius
    private int currentHealth;
    public bool hasMagicShield = false; // Ifall katten har sk�lden

    void Start()
    {
        currentHealth = maxHealth; //starta med den max liv  
    }

    public void TakeDamage(int damage)
    {
        if (hasMagicShield)
        {
            hasMagicShield = false;
            Debug.Log("Sk�lden tog skadan");

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
        Debug.Log("Katten �r d�d");
    }
}

    

