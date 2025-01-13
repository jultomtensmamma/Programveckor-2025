using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f; // Max avst�nd f�r attacken
    public int Damage = 10; // Skada som spelaren g�r

    void Update()
    {
        // Om v�nster musknapp trycks ned
        if (Input.GetMouseButtonDown(0))
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
            // Kolla om objektet �r en fiende
            if (hit.CompareTag("Enemy"))
            {
                // H�mta fiendens h�lsoskript och g�r skada
                EnemyHealthScript enemyHealth = hit.GetComponent<EnemyHealthScript>();
                if (enemyHealth != null)
                {
                    enemyHealth.health -= Damage;
                    Debug.Log("Enemy hit! Damage dealt: " + Damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Ritar en cirkel i scenen f�r att visa attackens r�ckvidd
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
