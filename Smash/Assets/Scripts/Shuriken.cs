using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {
    public GameObject bullet;
    public Player_Controller player;
    public float speed = 20f;

    private float cooldown = 0;
    private int facing = 1;

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetButtonDown("Fire1"))
        {
            bool pointUp = false;
            //anim.SetBool("throw", true);
            shoot(pointUp);
            Debug.Log(pointUp);
        }
    }
    public void shoot(bool pointUp)
    {
        if (cooldown > Time.time) return;
        if (pointUp)
        {
            Vector2 vertPos = new Vector2(player.GetComponent<Rigidbody2D>().position.x, player.GetComponent<Rigidbody2D>().position.y +2);
            GameObject vertB = (GameObject)Instantiate(bullet, vertPos, Quaternion.identity) as GameObject;
            vertB.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed));
            Destroy(vertB, 3);
            cooldown = Time.time + 2;
            return;
        }
        if (player.sprite.flipX)
        {
            facing = -1;
        }
        else
        {
            facing = 1;
        }
        Vector2 startPos = new Vector2(player.GetComponent<Rigidbody2D>().position.x + (2*facing), player.GetComponent<Rigidbody2D>().position.y);
        GameObject b = (GameObject)Instantiate(bullet, startPos, Quaternion.identity) as GameObject;
        b.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * facing, 0));
        Destroy(b, 3);
        cooldown = Time.time + 2;
    }
}
