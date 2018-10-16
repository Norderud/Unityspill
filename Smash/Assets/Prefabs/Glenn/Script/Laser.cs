using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float velX = 5f;
    private float velY = 0;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(velX,velY);
        Destroy(gameObject, 3f);

       
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider && collision.collider.tag == "Player")
        {
            Destroy(gameObject, 0f);
        }
    }
}
