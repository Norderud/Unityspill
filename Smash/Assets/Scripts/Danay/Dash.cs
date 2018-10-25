using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    public Rigidbody2D rb;
    public Controller controls;
    public Animator animator;

    public float coolDown;  // Determines how long the cooldown is
    private float coolDownTimer = 0; // Used to time cooldowns
    private float dashTime;     // Determines how long the dash will last
    public float startDashTime; // Determines how long the dash will last
    public float dashSpeed;     // Determines dash speed
    private bool isDashing = false;      // Determines if the player is dashing or not
    private bool hasDashed = false;      // Used to check if the player has dashed already in the air
    public bool input = false;

    public GameObject dashEffect;


    // Use this for initialization
    void Start () {
        dashTime = startDashTime;
        dashSpeed = 180;
        controls.enabled = true;
	}

    // Update is called once per frame
    void FixedUpdate () {
        Dashing();
        input = false;
    }
    private void Dashing() {
        if (!isDashing) {   //Dashes if dash is ready
            if (controls.grounded)
                hasDashed = false;
            if (input && coolDownTimer < Time.time && !hasDashed) { //Checks if button is clicked and cooldown is ready
                isDashing = true;
                hasDashed = true;
                animator.SetBool("IsDashing", true);    // dash animation
                FindObjectOfType<AudioManager>().Play("dash");  // Plays dash sound
                rb.GetComponent<Danay_Input>().enabled = false;   // disables user input while dashing
                Vector2 dashLocation = new Vector2(rb.position.x, rb.position.y - 2);   // Location for dasheffect
                GameObject myDashEffect = Instantiate(dashEffect, dashLocation, Quaternion.identity); // Instantiates a dash effect using prefab
                myDashEffect.transform.parent = rb.transform;   // sets dash effect as child to follow the player
            }
        }
        else {
            if (dashTime <= 0) {    // After dash is finished
                coolDownTimer = Time.time + coolDown;   // Sets the cooldown after the dash
                dashTime = startDashTime;               // Resets dashTime to startDashTime
                rb.velocity = Vector2.zero;             // Reset velocity after dash
                animator.SetBool("IsDashing", false);   // Cancels the dashing animation
                rb.GetComponent<Danay_Input>().enabled = true;
                isDashing = false;
            }
            else {  // If player is currently dashing
                dashTime -= Time.deltaTime;     // Counts down the duration of the dash
                if (controls.face)  // If facing left, dash left
                    rb.velocity = new Vector2(-1 * dashSpeed, 0);
                else // If facing right, dash right
                    rb.velocity = new Vector2(dashSpeed, 0);
            }
        }
    }
}
