using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiende : MonoBehaviour
{
    public int damage = 1; // Ger 1 skada

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CatHealth catHealth = collision.gameObject.GetComponent<CatHealth>();
        if (catHealth != null)
        {
            catHealth.TakeDamage(damage);
            Debug.Log("Katten nuddade maneten");
        }
    }
}

   