using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public Transform position;      // Reference to position
    public Rigidbody2D rb;          // Reference to rigidbody
    public Animator animator;       // Reference to animator
    public SpriteRenderer sprite;   // Reference to sprite
    public Boomerang boomerang;     // Reference to boomerang
    public GameObject doubleJumpEffect; // Referance to double jump effect
    public GameObject hitBox;       // Referance to hitBox

    public string player;           // Referance to if the character is player1 or player2


    public float m_speed = 1000f;   // Movement speed
    public float m_smooth = .05f;   // Smooth movement
    public float m_jump = 400f;     // Jump force
    public bool face = false;       // Determines which way the player faces. false = right

    public bool grounded = true;   // Determines if the player is in the air or not
    private bool jump = false;      // Is the player about to jump
    public bool doInput = true;     // Determines if it should check for input

    private int hasAirJumped = 0;   // 0 = grounded / 1 = in the air / 2 = has air jumped
    private float horizontal = 0;   // Detects if player is moving left/right. -1 is left, 1 is right

    //Attack variables
    private int hasAttacked = 0;    
    private float attackStart = 0;
    private float attackDuration = 0.4f;


    private Vector3 m_Velocity = Vector3.zero;  // Smooth move

    void Start() {
        if (PlayerPrefs.GetString("Player2tag") == "Danay") {
            player = "-2";
        }
    }


    private void Update() {

        hitBox.GetComponent<BoxCollider2D>().enabled = false;
        //////////////// ATTACKING

        //Resets attack
        if (attackStart > 0 && Time.time - attackStart > attackDuration) {
            attackStart = 0;
            hasAttacked = 0;
            animator.SetInteger("hasAttacked", hasAttacked);
        }
        if (Input.GetButtonDown("Fire1"+player) && hasAttacked < 3) { // Attack
            hitBox.GetComponent<BoxCollider2D>().enabled = true;
            hasAttacked++;
            attackStart = Time.time;
            animator.SetInteger("hasAttacked", hasAttacked);
        }
        //////////////////////////////

        if (Input.GetButtonDown("Fire3"+player) && !boomerang.fire) // Detects input for boomerang skill
        {
            boomerang.Shoot();  // Starts the boomerang update script
            boomerang.GetComponent<Renderer>().enabled = false; // Renders the boomerang
            boomerang.trail.enabled = false;    // Enables trail effect
        }

        if (doInput) // If detecting input is active, detects left/right input
            horizontal = Input.GetAxis("Horizontal"+player); // Gets input for horizontal movement

        if (horizontal < 0) {   // Player is facing left
            if (!face)
                hitBox.transform.position = new Vector2(hitBox.transform.position.x - 2.5f, hitBox.transform.position.y);
            face = true;    // Changes the players direction to left
            flip(face);
            
        }
        else if (horizontal > 0) {  // Player is facing right
            if (face)
                hitBox.transform.position = new Vector2(hitBox.transform.position.x + 2.5f, hitBox.transform.position.y);
            face = false;   // Changes the players direction to right
            flip(face);

        }

        if (Input.GetButtonDown("Jump"+player)) {  // Checks if player jumps
            jump = true;
            animator.SetBool("IsGrounded", false); // Sets the animator parameter
        }
    }


    // Update is called once per frame
    void FixedUpdate() {
        HandleMovement(horizontal, jump);   // Calls the method for handling movement
        jump = false;   // Resets the jump variable
    }

    void flip(bool flipper) {   // Flips the player
        sprite.flipX = flipper;
    }

    void HandleMovement(float move, bool jump) {
        animator.SetFloat("JumpSpeed", rb.velocity.y); // Tells the animator if the player is jumping up or falling down
        animator.SetFloat("Speed", Mathf.Abs(move));    // Animates if player is moving
        Vector3 moving = new Vector2(move * m_speed * Time.fixedDeltaTime, rb.velocity.y);  // Vector for moving the player
        rb.velocity = Vector3.SmoothDamp(rb.velocity, moving, ref m_Velocity, m_smooth);    // Smooth(?) movement

        if (jump && hasAirJumped < 2) { // Jumps
            grounded = false;   // Player is no longer grounded
            hasAirJumped++;     // Increments the number of jumps
            jump = false;   
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
            grounded = true;    // Sets the player as grounded
            animator.SetBool("IsGrounded", true);   // Sets the animator parameter to grounded
            hasAirJumped = 0;   // Resets the jump amount variable
        }
    }
    private void OnCollisionExit2D(Collision2D collision) { // Checks if the player is no longer grounded
        if (collision.gameObject.CompareTag("Ground")) {
            grounded = false;   // The player is no longer grounded
            animator.SetBool("IsGrounded", false);  // Sets the animator parameter to no longer grounded
            hasAirJumped = 1; // Sets the players jump amount variable to 1
        }
    }
}
