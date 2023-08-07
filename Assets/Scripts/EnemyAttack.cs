using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Fence _Fence;
    public int damage = 10;
   
   

   
    private void OnTriggerEnter(Collider other)
    {
        Fence fence = other.GetComponent<Fence>();
        if (fence != null)
        {
            _Fence = fence;

            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        if (_Fence.currentHealth > 0)
        {
            yield return new WaitForSeconds(1);
            if (_Fence != null) 
            _Fence.ReceiveDamage(damage);
            StartCoroutine(Attack());
        }
        else
        {
            _Fence = null;
           
        }
    }
  
    private void Update()
    {
        
    }
}
