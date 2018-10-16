using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Controller controller;

    public float force = 5000;
    private float duration = 0.3f;
    private float time;
    private bool isHitting;
    private GameObject treff;

    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Danay" ) {
            if (controller.face) force = -5000;
            else force = 5000;
            time = Time.time;
            isHitting = true;
          //collision.collider.gameObject.GetComponent<Player_Controller>().enabled = false;
            collision.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
        }
    }
}
