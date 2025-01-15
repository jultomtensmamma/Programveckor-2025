using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

    public float damage;
    public float enemyhealth = 100f;
    public float enemymaxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyhealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }
    void Damage(Collision other)
    {

        
            if (CompareTag("Enemy"))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    other.gameObject.GetComponent<EnemyHealthScript>().enemyhealth -= damage;
                }
                if (other.gameObject.CompareTag("DamageBubble"))
                {
                    enemyhealth -= damage;
                }
            }
            
        }
    }

