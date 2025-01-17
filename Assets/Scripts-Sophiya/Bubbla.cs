using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbla : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fiende"))
        {
            CatHealth catHealth = GetComponentInParent<CatHealth>();
            if (catHealth != null)
            {
                catHealth.TakeDamage(0);

            }
        }
    }
}



        
   