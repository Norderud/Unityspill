using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public GameObject right, left; // refference to hitbox left and right


    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag != "Glenn")
        {        
            if (right.GetComponent<BoxCollider2D>().enabled) // if player is facing right
            {       
                if (c.collider.tag == "Danay")
                {
                    c.collider.GetComponent<Controller>().enabled = false;//  sets Danays movementscript to false
                }
                else if(c.collider.tag == "Åsmund")
                {
                    c.collider.GetComponent<Player_Controller>().enabled = false; // sets åsmunds movementscript to false
                }

                c.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 800f)); // add force to enemy player
            }

            else // if player is facing left
            {                               
                if (c.collider.tag == "Danay")
                {
                    c.collider.GetComponent<Controller>().enabled = false; // sets Danays movementscript to false
                }
                else if (c.collider.tag == "Åsmund")
                {
                    c.collider.GetComponent<Player_Controller>().enabled = false; // sets åsmunds movementscript to false
                }

                c.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 800f)); // add force to enemy player
            }

        }

    }

   
}
