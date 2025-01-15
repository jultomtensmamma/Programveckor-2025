using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f; // Max avst�nd f�r attacken
    public int Damage = 10; // Skada som spelaren g�r
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

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
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        animator.Play("Nova attack");

        foreach (Collider2D hit in hits)
        {
            
            if (hit.CompareTag("Enemy"))
            {
                
                EnemyHealthScript enemyHealth = hit.GetComponent<EnemyHealthScript>();
                if (enemyHealth != null)
                {
                    enemyHealth.enemyhealth -= Damage;
                    Debug.Log("Enemy hit! Damage dealt: " + Damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
