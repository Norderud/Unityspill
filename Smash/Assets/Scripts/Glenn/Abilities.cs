using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {
    public Animator ani;
    public SpriteRenderer sprite;
    public Transform player;
    public GameObject laserR, laserL;
    private Vector2 laserPos;

    public string wPlayer;           // Referance to if the character is player1 or player2

    public Collider2D attackTriggerRight, attackTriggerLeft;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetString("Player2tag") == "Glenn"){
            wPlayer = "-2";
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        attackTriggerLeft.enabled = false;
        attackTriggerRight.enabled = false;
        Kick();
        Shoot();
    
    }


    private void Kick()
    {
        ani.SetBool("Kick", false);
        if (Input.GetButtonDown("Fire1"+ wPlayer))
        {
            if (sprite.flipX == false)
            {
                attackTriggerRight.enabled = true;
                ani.SetBool("Kick", true);
                ani.SetBool("Jump", false);
            }
            else
            {
                attackTriggerLeft.enabled = true;
                ani.SetBool("Kick", true);
                ani.SetBool("Jump", false);
            }

        }
   
    }

    private void Shoot()
    {

        ani.SetBool("Shoot", false);

        if (Input.GetButtonDown("Fire2"+ wPlayer) && Time.time > nextFire)
        {
            ani.SetBool("Shoot", true);
            ani.SetBool("Jump", false);
            nextFire = Time.time + fireRate;           
            laserPos = player.position;
            if (sprite.flipX == true)
            {
                laserL.GetComponent<SpriteRenderer>().flipX = true;
                laserPos += new Vector2(-1f, 0.5f );
                Instantiate(laserL,laserPos,Quaternion.identity);              
            }
            else
            {
                laserPos += new Vector2(1f, 0.5f);
                Instantiate(laserR, laserPos, Quaternion.identity);
            }
        }

    }
}
