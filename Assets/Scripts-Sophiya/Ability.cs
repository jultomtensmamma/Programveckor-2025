using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float speed = 5f;       // Hastighet f�r triangeln
    public int damage = 10;        // Skada triangeln g�r
    private Transform target;      // M�l (n�rmsta fiende)

    void Start()
    {
        FindClosestEnemy();
    }

    void Update()
    {
        // Om det finns ett m�l, r�r triangeln mot det
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // Om det inte finns n�gra fiender, f�rst�r triangeln
            Destroy(gameObject);
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            target = closestEnemy.transform;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Om triangeln tr�ffar en fiende
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // H�mta fiendens h�lsoskript och minska dess h�lsa
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // F�rst�ra triangeln
            Destroy(gameObject);
        }
    }
}
