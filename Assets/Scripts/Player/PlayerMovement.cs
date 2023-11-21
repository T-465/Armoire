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
    public bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public bool isJumping;
    public bool isDoubleJumping;
    private Animator anim;
    public bool canDoubleJump;
    public float jumpMultiplier = 1;

    // other script reference
    public PlayerCollisions playercollisions;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //get the horizontal input from the input manager
        input = Input.GetAxisRaw("Horizontal");

        //left movement animator and sprite
        if (input < -0.05f)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("Running", true);

        }
        //right movement animator and sprite
        else if (input > 0.05f)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("Running", true);
        }
        //not running
        else
        {
            anim.SetBool("Running", false);
        }



        // check for ground
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);



        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {

            Debug.Log("Single Jump" + isJumping);
            playerRb.velocity = Vector2.up * jumpForce;
            anim.SetBool("Jumping", true);

            Debug.Log("Single Jump");
        }

        if (Input.GetButtonDown("Jump") && isJumping == true && isDoubleJumping == false && canDoubleJump)
        {
            isDoubleJumping = true;
            playerRb.velocity = Vector2.up * (jumpForce * jumpMultiplier);
            anim.SetBool("DoubleJumping", true);

            Debug.Log("Double Jump");
        }

       if (isGrounded)
        {
            anim.SetBool("Jumping", false);
            isJumping=false;
            isDoubleJumping = false;
            anim.SetBool("DoubleJumping", false);
        }
        else
        {
            isJumping = true;
            anim.SetBool("Jumping", true);
        }

    }

     void FixedUpdate()
    {
        playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
    }


    





}
