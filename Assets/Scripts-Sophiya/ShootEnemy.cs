using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public GameObject trianglePrefab; // Prefab f�r triangeln
    public Transform firePoint;       // Position d�r triangeln skjuts ifr�n

    void Update()
    {
        // Kolla om spelaren trycker p� E knappen
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnTriangle();
        }
    }

    void SpawnTriangle()
    {
        // Skapa triangeln vid firePoint
        Instantiate(trianglePrefab, firePoint.position, Quaternion.identity);
    }

}



  