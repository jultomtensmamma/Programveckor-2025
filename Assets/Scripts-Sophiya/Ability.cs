using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float speed = 5f;       // Hastighet för triangeln
    public int damage = 10;        // Skada triangeln gör
    private Transform target;      // Mål (närmsta fiende)

    void Start()
    {
        FindClosestEnemy();
    }

    void Update()
    {
        // Om det finns ett mål, rör triangeln mot det
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // Om det inte finns några fiender, förstör triangeln
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
        // Om triangeln träffar en fiende
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Hämta fiendens hälsoskript och minska dess hälsa
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Förstöra triangeln
            Destroy(gameObject);
        }
    }
}
