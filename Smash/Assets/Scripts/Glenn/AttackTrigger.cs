using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public GameObject right, left;
    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag != "Glenn")
        {
            if (right.GetComponent<BoxCollider2D>().enabled)
            {
                c.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5000f, 800f));
            }
            else
            {                
                c.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5000f, 800f));
            }
        }
    }
}
