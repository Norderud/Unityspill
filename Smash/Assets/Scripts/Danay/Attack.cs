using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Controller controller;

    public float force = 50;
    private float duration = 0.3f;
    private bool isHitting;
    private GameObject treff;
    private int direction;

    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
}
