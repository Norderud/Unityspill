using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {
    public GameObject bullet;
    public Player_Controller player;
    public float speed = 20f;
    public float cooldown = 1f;

    private float tTime = 0f;
    private int facing = 1;

    public void shoot()
    {
        if (tTime > Time.time) return;
        if (player.sprite.flipX)
        { 
            facing = -1;
        }
        else
        {
            facing = 1;
        }
        player.anim.SetBool("throw", true);
        Vector2 startPos = new Vector2(player.GetComponent<Rigidbody2D>().position.x + (1.3f*facing), player.GetComponent<Rigidbody2D>().position.y);
        GameObject b = (GameObject)Instantiate(bullet, startPos, Quaternion.identity) as GameObject;
        b.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * facing, 0));
        Destroy(b, 3);
        tTime = Time.time + cooldown;
    }
}
