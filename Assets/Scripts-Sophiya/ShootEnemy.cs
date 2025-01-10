using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public GameObject trianglePrefab;
    public Transform firepoint;
    public float projectileSpeed = 12f;
    public float projectileLifetime = 6f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootTriangle();
        }
    }
    void ShootTriangle()
    {
        GameObject triangle = Instantiate(trianglePrefab, firepoint.position, firepoint.rotation);
        triangle.transform.rotation = Quaternion.Euler(0, 90, 0);
        Rigidbody rb = triangle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = triangle.transform.right * projectileSpeed;
        }


        Destroy(triangle, projectileLifetime);
        {


        }

    }

}
