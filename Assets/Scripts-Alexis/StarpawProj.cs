using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarpawProj : MonoBehaviour
//Alexis
{

    private int damage; 

    public void SetDamage(int dmg)
    {
        damage = dmg; 
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealthScript enemyHealth = collision.gameObject.GetComponent<EnemyHealthScript>();
        {
            enemyHealth.TakeDamage(damage);

        }

        Destroy(gameObject);
    }
}
