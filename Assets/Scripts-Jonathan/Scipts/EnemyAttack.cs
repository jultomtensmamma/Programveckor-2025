using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f; // Max avst�nd f�r attacken
    public int attackDamage = 10; // Skada som fienden g�r
    public float attackCooldown = 1f; // Tid mellan attacker

    private float nextAttackTime = 0f;

    void Update()
    {
        // Om fienden kan attackera (ingen cooldown)
        if (Time.time >= nextAttackTime)
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Hitta alla colliders inom attackens r�ckvidd
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D hit in hits)
        {
            // Kolla om objektet �r en spelare
            if (hit.CompareTag("Player"))
            {
                // H�mta spelarens h�lsoskript och g�r skada
                HealthScript playerHealth = hit.GetComponent<HealthScript>();
                if (playerHealth != null)
                {
                    playerHealth.health -= attackDamage;
                    Debug.Log("Player hit! Damage dealt: " + attackDamage);
                    nextAttackTime = Time.time + attackCooldown; // Starta cooldown
                    return;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Ritar en cirkel i scenen f�r att visa attackens r�ckvidd
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
