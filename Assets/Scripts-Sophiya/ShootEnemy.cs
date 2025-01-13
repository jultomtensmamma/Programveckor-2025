using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public GameObject trianglePrefab; // Prefab för triangeln
    public Transform firePoint;       // Position där triangeln skjuts ifrån

    void Update()
    {
        // Kolla om spelaren trycker på E knappen
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



  