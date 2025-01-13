using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MonoBehaviour
{
    public GameObject shieldVisual;
    private bool shieldActive = false; //Kontrollerar ifall skölden är aktiv
    private bool shieldUsed = false; //Kontrollerar ifall skölden redan har skyddat mot skada

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
            shieldActive = false; //Skölden/bubblan försvinner
            shieldUsed = true; //Markera att skölden har använts
            if (shieldVisual != null)
            {
                shieldVisual.SetActive(false); //Döljer bubblan
            }
            Debug.Log("Skölden tog skada");
        }
        else
        {
            ApplyDamage(damage);// Apllicerar skada ifall ingen sköld används

        }
    }

    void ApplyDamage(int damage)
    {
        Debug.Log("Katten förlora 1 liv!");
    }
}
