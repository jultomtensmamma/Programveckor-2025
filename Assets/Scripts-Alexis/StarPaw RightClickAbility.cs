using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickAbility : MonoBehaviour
//Alexis
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    public int damage = 10;
    public float energyPerShot = 10f;

    private EnergyBurstAbility energyBurst;

    void Start()
    {
        energyBurst = GetComponent<EnergyBurstAbility>();

    }

    public void UseAbility()
    {
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * projectileSpeed;

        StarpawProj projScript = projectile.GetComponent<StarpawProj>();
        if (projScript != null)
        {
            projScript.SetDamage(damage); 
        }
        if (energyBurst != null)
        {
            energyBurst.AddEnergy(energyPerShot); 
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
