﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {

    public SpriteRenderer sprite;
    public Transform player;
    private Rigidbody2D rb;
    public Animator ani;
    
    private int moveSpeed = 15;
    private int fuel = 100;
    private float jumpforce = 1000;
    private bool jump = true;

    public static bool tel;
    private float teleportRange = 250;


    private float flyForce = 100f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
     
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        Jump();
        Move();
        Teleport();
    }

    
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
       
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (horizontal < 0)
        {
            sprite.flipX = true;
            ani.SetFloat("Speed", 1);
        }
        else if(horizontal > 0)
        {
            sprite.flipX = false;
            ani.SetFloat("Speed",1);
        }
        else
        {
            ani.SetFloat("Speed",0);
        }
        
    }

    private void Jump() {

        if (Input.GetButton("Jump") && fuel > 0 && player.position.y <= 10)
        {

            if (jump == true)
            {
                rb.AddForce(new Vector2(0, jumpforce));
                jump = false;
              
            }
            ani.SetBool("Jump", true);
            ani.SetBool("IsGrounded", false);

            rb.AddForce(new Vector2(0, flyForce));
            fuel--;
        }

 

    }

        void OnCollisionEnter2D(Collision2D col) // check collision
    {
        if (col.collider.tag == "Ground") // resets jump and fly values
        {
            ani.SetBool("IsGrounded", true);
            ani.SetBool("Jump", false);
            fuel = 100;
            jump = true;
            tel = true;
           
        }
    }

    private void Teleport()
    {
        // tel = true;
        if (Input.GetButtonDown("Fire3") && tel)
        {
            if (sprite.flipX == false)
            {
                rb.velocity = Vector2.right * teleportRange;
                tel = false;
            }
            else
            {
                rb.velocity = Vector2.left * teleportRange;
                tel = false;
            }
        }
    }
}


  

