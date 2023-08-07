
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Bullet : MonoBehaviour
    {
        public int damageAmount = 20;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected: " + collision.gameObject.tag);
       
        if (collision.gameObject.CompareTag("Enemy"))
        {          
            EnemySettings enemyHealth = collision.gameObject.GetComponent<EnemySettings>();

            if (enemyHealth != null)
            {
                enemyHealth.ReceiveDamage(damageAmount);
            }
        }       
    }
    private void Update()
    {
        Invoke("DieInTime", 3f);
    }
    void DieInTime()
    {      
        Destroy(gameObject);
    }
}
