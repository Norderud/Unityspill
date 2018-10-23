using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danay_Input : MonoBehaviour {

    public Rigidbody2D rb;          // Referance to rigidbody
    public Boomerang boomerang;     // Reference to boomerang
    public Controller move;         // Referance to movement
    public Attack attack;
    public string player;           // Referance to if the character is player1 or player2

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetString("Player2tag") == "Danay")
            player = "-2";
    }
	
	// Update is called once per frame
	void Update () {
        //DASH
        if (Input.GetButtonDown("Fire2" + player))
            rb.GetComponent<Dash>().input = true;

        // Boomerang
        if (Input.GetButtonDown("Fire3" + player) && !boomerang.fire) // Detects input for boomerang skill
            Boomerang();

        //// attack
        if (Input.GetButtonDown("Fire1" + player))
            attack.Attacking();

        // Jumping
        if (Input.GetButtonDown("Jump" + player)) {  // Checks if player jumps
            move.Jump();
        }

        // Movement
        move.horizontal = Input.GetAxis("Horizontal" + player); // Gets input for horizontal movement

    }

    // Method for boomerang input
    private void Boomerang() {
        boomerang.Shoot();  // Starts the boomerang update script
        boomerang.GetComponent<Renderer>().enabled = false; // Renders the boomerang
        boomerang.trail.enabled = false;    // Enables trail effect
    }


}
