using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

    public SpriteRenderer playerSprite; // Players sprite
    public Rigidbody2D rb;  // boomerangs rigidbody
    public Rigidbody2D pRb; // players rigidbody
    public TrailRenderer trail; // Boomerang trail
    public GameObject boomerang;

    public bool fire = false;   // Bool for if the player has fired the boomerang


    public float distance = 5f; // Distance before turning back
    public float startSpeed = 70f;    // How fast the boomerang is
    private float speed;            // The variable used to determine how fast and which direction

    private float currentDistance; // How far it has traveled

    private bool returning = false;    // Determines if the boomerang is returning or not
    private bool shoot = false;        
    private int direction;          // Direction. -1 is left, 1 is right
    private bool treff = false;     // Determines if the boomerang has hit something

    private float startDist;    //Starting distance

    public void Shoot()
    {
        fire = true;    // Boomerang has been fired
        boomerang.SetActive(true);  // Enables the script
    }
    void Start()
    {
        boomerang.SetActive(false); // Disables the script
    }
    void Reset() // Resets the boomerang values
    {
        shoot = false;  // Is no longer shooting
        returning = false; // Is no longer returning
        speed = startSpeed; // Resets speed
        fire = false;   // Is no longer fired
        boomerang.SetActive(false); // Deactivated
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (!shoot) // When it shoots
        {
            if (playerSprite.flipX) // Determines which direction to throw 
                direction = -1;
            else
                direction = 1;

            rb.position = new Vector2(pRb.position.x+3*direction, pRb.position.y);  // Sets the position to right next to the player, if its on top it will hit the player
            startDist = rb.position.x;  // Start position of the boomerang
            boomerang.GetComponent<Renderer>().enabled = true;  // Renders the boomerang
            trail.enabled = true;   // Enables the trail effect
            treff = false;  // Not hit anything
            shoot = true;   // Is currently shooting
            
            speed = startSpeed * direction; // determines the speed and direction to throw
            rb.velocity = new Vector2(speed, 0);    // Sets the velocity of the boomerang
        }

        if (!returning && shoot && 
                Mathf.Abs(Mathf.Min(rb.position.x, startDist) - Mathf.Max(rb.position.x, startDist))
                >= distance) { // When it turns around
            returning = true;   // Is currently returning
            speed *= -1;        // Turns the boomerang around
            rb.velocity = new Vector2(speed, 0);    // Sets the new velocity
        }
        else if (returning && shoot && Mathf.Abs(rb.position.x - startDist) < 0.5) { // WHen it returns
            Reset();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Danay") {
            Reset();    // Resets the values
        }
        if (collision.gameObject.tag != "Danay" || collision.gameObject.tag != "Weapon") { // If the boomerang hits something 
            returning = true;   // Is currently returning
            speed *= -1;    // Turns the boomerang around
            rb.velocity = new Vector2(speed, 0);    // Sets the new velocity
        }
    }
}
