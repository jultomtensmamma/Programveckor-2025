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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<EnemyHealthScript>().enemyhealth -= damage;
        }
        
    }
    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); 
    }
}
