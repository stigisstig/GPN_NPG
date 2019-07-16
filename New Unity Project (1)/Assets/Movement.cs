using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float sprintspeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public BulletTime bullet;
    public Quaternion callit(Quaternion qu)
    {
        Quaternion holy = qu;
        return holy;
    }



    private Vector3 moveDirection = Vector3.zero;

    Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    public void palyermovement()
    {
        float PlayerFacing = transform.rotation.y;
        animator.SetFloat("Debugdig", PlayerFacing);
        float playermove = Input.GetAxis("Horizontal");
        if (characterController.isGrounded)
        {


            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;

            animator.SetFloat("movenig", playermove);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            }
            else
            {
                animator.ResetTrigger("Jump");
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Sprint", true);
                moveDirection *= sprintspeed;
            }
            else
            {
                animator.SetBool("Sprint", false);
            }
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Crouch", true);
            }
            else
            {
                animator.SetBool("Crouch", false);
            }
            if (Input.GetKey(KeyCode.J))
            {
                bool coolattack = true;
                animator.SetTrigger("Attack1");
            }
            else
            {
                animator.ResetTrigger("Attack1");
            }
            if ((animator.GetAnimatorTransitionInfo(0).IsName("readyjump -> JumpItSelf")) || (animator.GetAnimatorTransitionInfo(0).IsName("readyjump -> Dope")))
            {
                animator.SetBool("CoolAttack", true);
                animator.SetBool("debug1", true);
                moveDirection.y = jumpSpeed;
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dope"))
            {
                animator.SetBool("CoolAttack", false);
            }
            




        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            bullet.bulletbullettime();
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            bullet.backtonormal();
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void Update()
    {
        palyermovement();

    }
}

