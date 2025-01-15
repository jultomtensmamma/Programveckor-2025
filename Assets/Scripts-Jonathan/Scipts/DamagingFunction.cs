using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DamagingFunction : MonoBehaviour
{

    public float damage = 25f;


    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);


        EnemyHealthScript EnemyhealthScript = other.gameObject.GetComponent<EnemyHealthScript>();
        if (EnemyhealthScript != null && other.gameObject.CompareTag("Enemy"))
        {

            EnemyhealthScript.enemyhealth = Mathf.Clamp(EnemyhealthScript.enemyhealth + damage, 0, EnemyhealthScript.enemymaxHealth);
            Debug.Log("Dealt " + damage + " damage to " + other.gameObject.name);


            Destroy(gameObject);
        }
    }
}

