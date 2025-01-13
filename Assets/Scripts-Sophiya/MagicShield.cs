using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MonoBehaviour
{
    public GameObject shieldVisual;
    private bool shieldActive = false; //Kontrollerar ifall sk�lden �r aktiv
    private bool shieldUsed = false; //Kontrollerar ifall sk�lden redan har skyddat mot skada

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !shieldActive && !shieldUsed)
        {
            ActiveShield();
        }
    }

    void ActiveShield()
    {
        shieldActive = true;
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true); //Bubblan kommer fram
        }
    }

    public void TakeDamage(int damage)
    {
        if (shieldActive)
        {
            shieldActive = false; //Sk�lden/bubblan f�rsvinner
            shieldUsed = true; //Markera att sk�lden har anv�nts
            if (shieldVisual != null)
            {
                shieldVisual.SetActive(false); //D�ljer bubblan
            }
            Debug.Log("Sk�lden tog skada");
        }
        else
        {
            ApplyDamage(damage);// Apllicerar skada ifall ingen sk�ld anv�nds

        }
    }

    void ApplyDamage(int damage)
    {
        Debug.Log("Katten f�rlora 1 liv!");
    }
}
