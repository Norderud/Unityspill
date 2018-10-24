using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float velX = 5f;
    private float velY = 0;
    private Rigidbody2D rb;
    public static bool right;
    public GameObject smoke;
    


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        rb.velocity = new Vector2(velX,velY);
        Destroy(gameObject, 3f);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.tag != "Glenn")
        {
            GameObject myDashEffect = Instantiate(smoke, rb.transform.position, Quaternion.identity) as GameObject;  // adds smoke when laser hit        
            Destroy(gameObject, 0f);
            if (collision.collider.GetComponent<Stats>() != null)
            {
                collision.collider.GetComponent<Stats>().TakeDmg(10); // add damage to enemy             
            }
            else
            {
                return;
            }          
        }
        else
        {
            return;
        }
     
    }
}
