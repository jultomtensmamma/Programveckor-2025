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
    void Damage(Collision other)
    {
        DamagingFunction Damage = other.gameObject.GetComponent<DamagingFunction>();
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<EnemyHealthScript>().enemyhealth -= damage;
        }
        if (other.gameObject.CompareTag("DamageBubble"))
        {
            enemyhealth -= damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
       

    }
    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); 
    }
}
