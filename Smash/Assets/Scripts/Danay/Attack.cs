using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    // Referances
    public Controller controller;   // Referance to movement 
    public Animator animator;       // Reference to animator
    public GameObject hitBox;       // Referance to hitBox
    public GameObject blood;    // Blood particle

    //Hitbox/force variables
    public float force = 12000;    
    private float duration = 0.3f;
    private bool isHitting;
    private GameObject treff;
    private int direction;

    //Attack duration/combo variables
    private int hasAttacked = 0;
    private float attackStart = 0;
    private float attackDuration = 0.5f;
    private float hitDuration = 0.02f; // Hitbox activation duration
    private float coolDown = 0.25f;

    void Update() {

        if (Time.time-attackStart>hitDuration)
            hitBox.GetComponent<BoxCollider2D>().enabled = false;   // Disables hitbox

        // Resets attack
        if (attackStart > 0 && Time.time - attackStart > attackDuration) {
            ResetAttack();
        }
    }


    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "Danay" ) {
            if (controller.face) direction = -1;
            else direction = 1;
            isHitting = true;
            Vector2 pos = collision.GetComponent<Transform>().position;
            GameObject bloodEffect;
            switch (collision.tag) {
                case ("Åsmund"):
                    collision.gameObject.GetComponent<Player_Controller>().enabled = false;
                    collision.gameObject.GetComponent<Stats>().TakeDmg(10);
                    bloodEffect = Instantiate(blood, pos, Quaternion.identity) as GameObject;
                    bloodEffect.transform.parent = collision.GetComponent<Rigidbody2D>().transform;
                    FindObjectOfType<AudioManager>().Play("bam");
                    break;
                case ("Glenn"):
                    collision.gameObject.GetComponent<Movement>().enabled = false;
                    collision.gameObject.GetComponent<Stats>().TakeDmg(10);
                    bloodEffect = Instantiate(blood, pos, Quaternion.identity);
                    bloodEffect.transform.parent = collision.GetComponent<Rigidbody2D>().transform;
                    FindObjectOfType<AudioManager>().Play("bam");
                    break;
            }
            if (hasAttacked < 3)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 0));
            else
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(force * direction, force));
        }
    }


    public void Attacking() {
        if (hasAttacked < 3 && Time.time - attackStart > coolDown) { // Attack cd
            if (controller.grounded)
            {  // Disables movement and stops the player
                controller.gameObject.GetComponent<Danay_Input>().EnableMove(false);
                controller.horizontal = 0;
                hasAttacked++;
            }
            else
                hasAttacked = 3;
            FindObjectOfType<AudioManager>().Play("hit" + (hasAttacked));
            hitBox.GetComponent<BoxCollider2D>().enabled = true;
            attackStart = Time.time;
            animator.SetInteger("hasAttacked", hasAttacked);
        }
    }
    public void MoveHitBox(bool direction) {
        if (direction)
            hitBox.transform.position = new Vector2(hitBox.transform.position.x + 1.8f, hitBox.transform.position.y);
        else
            hitBox.transform.position = new Vector2(hitBox.transform.position.x - 1.8f, hitBox.transform.position.y);
    }

    public void ResetAttack() {
        attackStart = 0;
        hasAttacked = 0;
        animator.SetInteger("hasAttacked", hasAttacked);
        controller.gameObject.GetComponent<Danay_Input>().EnableMove(true);
    }
}
