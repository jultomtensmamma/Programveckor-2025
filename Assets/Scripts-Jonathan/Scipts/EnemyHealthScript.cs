using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public HealthScript Phealth;
    public float damage;
    public float health = 100f;
    public float maxHealth = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthScript>().health -= damage;
        }
    }
    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); 
    }
}
