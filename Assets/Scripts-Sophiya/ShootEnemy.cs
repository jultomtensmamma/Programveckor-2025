using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firepoint;
    public float projectileSpeed = 12f;
    public float projectileLifetime = 6f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firepoint.forward * projectileSpeed;
        }
        Destroy(projectile, projectileLifetime);
    }

}
