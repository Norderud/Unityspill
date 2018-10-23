using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    // Referances
    public Controller controller;   // Referance to movement 
    public Animator animator;       // Reference to animator
    public GameObject hitBox;       // Referance to hitBox

    //Hitbox/force variables
    public float force = 50;    
    private float duration = 0.3f;
    private bool isHitting;
    private GameObject treff;
    private int direction;

    //Attack duration/combo variables
    private int hasAttacked = 0;
    private float attackStart = 0;
    private float attackDuration = 0.4f;

    void Update() {

        // Resets attack
        if (attackStart > 0 && Time.time - attackStart > attackDuration) {
            attackStart = 0;
            hasAttacked = 0;
            animator.SetInteger("hasAttacked", hasAttacked);
            hitBox.GetComponent<BoxCollider2D>().enabled = false;   // Disables hitbox
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag != "Danay" ) {
            if (controller.face) direction = -1;
            else direction = 1;
            isHitting = true;
            switch (collision.collider.tag) {
                case ("Åsmund"):
                    collision.collider.gameObject.GetComponent<Player_Controller>().enabled = false;
                    collision.collider.gameObject.GetComponent<Stats>().TakeDmg(10);
                    break;
                case ("Glenn"):
                    collision.collider.gameObject.GetComponent<Movement>().enabled = false;
                    collision.collider.gameObject.GetComponent<Stats>().TakeDmg(10);
                    break;
            }
            collision.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force*direction, force*10));
        }
    }

    public void Attacking() {
        if (hasAttacked < 3) { // Attack
            hitBox.GetComponent<BoxCollider2D>().enabled = true;
            hasAttacked++;
            attackStart = Time.time;
            animator.SetInteger("hasAttacked", hasAttacked);
        }
    }
    public void MoveHitBox(bool direction) {
        if (direction)
            hitBox.transform.position = new Vector2(hitBox.transform.position.x + 2.5f, hitBox.transform.position.y);
        else
            hitBox.transform.position = new Vector2(hitBox.transform.position.x - 2.5f, hitBox.transform.position.y);
    }
}
