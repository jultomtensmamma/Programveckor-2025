using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScriptLevel4 : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    private void Die()
    {
        Destroy(gameObject); 
    }
}
