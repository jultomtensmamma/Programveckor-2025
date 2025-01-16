using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool isStunned = false;
    private float stunEndTime;

    void Update()
    {
        if (isStunned && Time.time >= stunEndTime)
        {
            isStunned = false; // Ta bort stun-effekten
        }

        if (!isStunned)
        {
            MoveAndAttack(); // Fienden rör sig och attackerar som vanligt
        }
    }

    public void Stun(float duration)
    {
        isStunned = true;
        stunEndTime = Time.time + duration;
        Debug.Log($"{gameObject.name} is stunned for {duration} seconds!");
    }

    private void MoveAndAttack()
    {
        // Logik för fiendens rörelse och attack
    }
}