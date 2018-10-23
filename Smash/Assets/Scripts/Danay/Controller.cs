using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    /// REFERENCES
    public Transform position;      // Reference to position
    public Rigidbody2D rb;          // Reference to rigidbody
    public Animator animator;       // Reference to animator
    public SpriteRenderer sprite;   // Reference to sprite
    public GameObject doubleJumpEffect; // Referance to double jump effect
    public Attack attack;

    /// Movement variables
    public float m_speed = 1000f;   // Movement speed
    public float m_smooth = .05f;   // Smooth movement
    public float m_jump = 400f;     // Jump force
    private Vector3 m_Velocity = Vector3.zero;  // Smooth move

    // Condition variables
    public bool face = false;       // Determines which way the player faces. false = right
    public bool grounded = true;   // Determines if the player is in the air or not

    private int hasAirJumped = 0;   // 0 = grounded / 1 = in the air / 2 = has air jumped
    public float horizontal = 0;   // Detects if player is moving left/right. -1 is left, 1 is right

    private void Update() {

        if (horizontal < 0) {   // Player is facing left
            if (!face) 
                attack.MoveHitBox(false);
            face = true;    // Changes the players direction to left
            sprite.flipX = face;
        }
        else if (horizontal > 0) {  // Player is facing right
            if (face)
                attack.MoveHitBox(true);
            face = false;   // Changes the players direction to right
            sprite.flipX = face;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        HandleMovement(horizontal);   // Calls the method for handling movement
    }

    // Handles walking left or right
    void HandleMovement(float move) {
        animator.SetFloat("JumpSpeed", rb.velocity.y); // Tells the animator if the player is jumping up or falling down
        animator.SetFloat("Speed", Mathf.Abs(move));    // Animates if player is moving
        Vector3 moving = new Vector2(move * m_speed * Time.fixedDeltaTime, rb.velocity.y);  // Vector for moving the player
        rb.velocity = Vector3.SmoothDamp(rb.velocity, moving, ref m_Velocity, m_smooth);    // Smooth(?) movement
    }

    // Method for jumping
    public void Jump() {
        if (hasAirJumped < 2) { // Number of jumps
            animator.SetBool("IsGrounded", false); // Sets the animator parameter
            hasAirJumped++;     // Increments the number of jumps
            rb.velocity = new Vector2(rb.velocity.x, 0f);   // Sets the velocity for the jump
            rb.AddForce(new Vector2(0f, m_jump));
            if (hasAirJumped > 1) {
                Vector2 jumpEffectLocation = new Vector2(rb.position.x, rb.position.y - 2);   // Location for jump effect
                GameObject myJumpEffect = Instantiate(doubleJumpEffect, jumpEffectLocation, Quaternion.identity) as GameObject;
                myJumpEffect.transform.parent = rb.transform; // Sets the jump effect as players child
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {    // Checks if the player is grounded or not
        if (collision.gameObject.CompareTag("Ground")) {
            animator.SetBool("IsGrounded", true);   // Sets the animator parameter to grounded
            hasAirJumped = 0;   // Resets the jump amount variable
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) { // Checks if the player is no longer grounded
        if (collision.gameObject.CompareTag("Ground")) {
            animator.SetBool("IsGrounded", false);  // Sets the animator parameter to no longer grounded
            hasAirJumped = 1; // Sets the players jump amount variable to 1
            grounded = false;
        }
    }
}
