using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBurstAbility : MonoBehaviour

    //Alexis
{
    public float maxEnergy = 100f;
    public int energyBurstDamage = 50;
    public float pushForce = 10f;
    public float radius = 10f;

    private float currentEnergy = 0f; 

    public void UseAbility()
    {
        if (currentEnergy >= maxEnergy)
        {
            EnergyBurst();
            currentEnergy = 0f; 
        }
    }



    // Update is called once per frame
    public void AddEnergy(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    private void EnergyBurst()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var enemy in enemies)
        {
            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 pushDirection = (enemy.transform.position).normalized;
                enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }

            EnemyHealthScriptLevel4 enemyhealth = enemy.GetComponent<EnemyHealthScriptLevel4>();
            if (enemyhealth != null)
            {
                enemyhealth.TakeDamage(energyBurstDamage);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
