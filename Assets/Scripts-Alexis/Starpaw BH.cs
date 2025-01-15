using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class BlackHole : MonoBehaviour
    //Alexis
{

    private int damage;
    private float delay;
    private float duration;
    private float pullForce;
    private float pullRadius;
    private bool isActivated = false;

    public void Initialize(int dmg, float delayTime, float durationTime, float force, float radius)
    {
        damage = dmg;
        delay = delayTime;
        duration = durationTime;
        pullForce = force;
        pullRadius = radius;
        Invoke(nameof(ActivatedBlackHole), delay);
        Destroy(gameObject, delay + duration);

    }

    // Update is called once per frame
    void ActivatedBlackHole()
    {
        isActivated = true;
    }

    private void FixedUpdate()
    {
        if (isActivated)
        {
            PullEnemies();
        }
    }

    private void PullEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pullRadius);
        foreach (var collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 pullDirection = (transform.position - collider.transform.position).normalized;
                rb.AddForce(pullDirection * pullForce * Time.fixedDeltaTime);

                EnemyHealthScriptLevel4 enemyHealth = collider.GetComponent<EnemyHealthScriptLevel4>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }

        }

    
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }
}
