
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 20f;
    public float fireRate = 0.2f;

    private float nextFireTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }


    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
       
        Bullet bulletScript = projectile.GetComponent<Bullet>();
        if (bulletScript)
        {
            bulletScript.damageAmount = 20; 
        }
    
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
    }
}
