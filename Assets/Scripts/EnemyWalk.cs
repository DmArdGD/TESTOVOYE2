using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float gravity = 9.81f;
    public LayerMask obstacleLayer;
    Animator animator;
    private CharacterController characterController;
    private bool isWalking = true;
    EnemyAttack attack;

    private void Start()
    {
       animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
      
    }

    private void Update()
    {
        if (isWalking)
        {
            animator.SetBool("Walk", true);
            Vector3 moveDirection = -transform.forward * walkSpeed;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
       
        if (!characterController.isGrounded)
        {
            characterController.Move(Vector3.down * gravity * Time.fixedDeltaTime);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
        if (((1 << hit.gameObject.layer) & obstacleLayer) != 0)
        {
         
            isWalking = false;
            animator.SetBool("Walk", false);
            attack.GetComponent<EnemyAttack>().Attack();
           
        }
    }
 
}
