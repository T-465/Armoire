using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerMovement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;
    private Animator anim;
    private bool canDoubleJump;

    void Update()
    {
        anim = GetComponent<Animator>();


        input = Input.GetAxisRaw("Horizontal");

        if (input < 0)
        {
            spriteRenderer.flipX = true;

        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }

        //  Running Animator

        if (input > 0)
        {
            anim.SetBool("Running", true);
        }
        else if (input < 0)
        {
            anim.SetBool("Running", true);
        }
        else 
        {
            anim.SetBool("Running", false);

        }





        // check for ground

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);



        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;

        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;

            }
            
            else 
            { 
                isJumping = false;
            
            }

        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;

        }

        // Jumping Animator
        if (isJumping == true)
        {
            anim.SetBool("Jumping", true);

        }
        else if (isJumping == false)
        {
            anim.SetBool("Jumping", false);

        }


        // Double Jump
         if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            playerRb.velocity = Vector2.up * jumpForce;
            

            canDoubleJump = false;
        }

    }

     void FixedUpdate()
    {
        playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
    }


    
       // other script reference
        public PlayerCollisions playercollisions;

        void Start()
        {
            bool swordcollected = playercollisions.swordcollected;

            if (swordcollected == true)
            {
               canDoubleJump = true;

            }
        }


}
