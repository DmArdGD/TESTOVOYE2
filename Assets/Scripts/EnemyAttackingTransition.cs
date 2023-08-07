using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingTransition : MonoBehaviour
{
  
    private bool NeedAttack;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
       
    }
    private void Update()
    {
        if (NeedAttack)
        {  
            NeedAttack = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       Fence fence = other.GetComponent<Fence>();
        if (fence != null)
        {

            if (fence.currentHealth > 0)
            animator.SetTrigger("Attack");
            NeedAttack = true;
         
        }
    }
}
