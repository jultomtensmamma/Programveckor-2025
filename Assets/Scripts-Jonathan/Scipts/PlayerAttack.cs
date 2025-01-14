using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f; // Max avstånd för attacken
    public int Damage = 10; // Skada som spelaren gör
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()

    {
        // Om vänster musknapp trycks ned
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Hitta alla colliders inom attackens räckvidd
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        animator.Play("Nova attack");

        foreach (Collider2D hit in hits)
        {
            // Kolla om objektet är en fiende
            if (hit.CompareTag("Enemy"))
            {
                // Hämta fiendens hälsoskript och gör skada
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
        // Ritar en cirkel i scenen för att visa attackens räckvidd
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
