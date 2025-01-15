using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleAbility : MonoBehaviour
//Alexis
{

    public GameObject blackHolePrefab;
    public Transform firePoint;
    public float delay = 2f;
    public float duration = 3f;
    public int damage = 50;
    public float pullForce = 5f;
    public float pullRadius = 5f;

    public void UseAbility()
    {
        CreateBlackHole();
    }

    // Update is called once per frame
    private void CreateBlackHole()
    {
        GameObject blackHole = Instantiate(blackHolePrefab, firePoint.position, firePoint.rotation);
        BlackHole bhScript = blackHole.GetComponent<BlackHole>();

        if (bhScript != null)
        {
            bhScript.Initialize(damage, delay, duration, pullForce, pullRadius);
        }
    }
}
