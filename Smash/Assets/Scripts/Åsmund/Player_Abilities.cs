using System;
using UnityEngine;

public class Player_Abilities : MonoBehaviour
{
    public GameObject bullet;
    public Player_Controller player;
    public float speed = 3000f;
    public float cooldown;
    public Kick kick;
    public Smash smash;

    private float tTime = 0f;
    private int facing = 1;
    private string wPlayer;
    void Start()
    {
        if (PlayerPrefs.GetString("Player2tag") == "Åsmund")
        {
            wPlayer = "-2";
        }
    }
    private void Update()
    {
        resetValues();
        if (player.sprite.flipX)
        {
            facing = -1;
        }
        if (Input.GetButtonDown("Fire2"+wPlayer))
        {
            shoot();
        }
        if (Input.GetButtonDown("Fire1" + wPlayer))
        {
            attack();
        }
        if(Input.GetButtonDown("Fire3" + wPlayer))
        {
            smashAttack();
        }
    }

    public void shoot()
    {
        if (tTime > Time.time) return;
        player.anim.SetBool("throw", true);
        Vector2 startPos = new Vector2(player.GetComponent<Rigidbody2D>().position.x + (1.5f * facing), player.GetComponent<Rigidbody2D>().position.y);
        Instantiate(bullet, startPos, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * facing, 0));
        tTime = Time.time + cooldown;
    }
    public void attack()
    {
        if (tTime > Time.time) return;
        kick.moveCollider(facing);
        kick.kick();
        player.anim.SetBool("attack", true);
        tTime = Time.time + cooldown;
    }
    public void smashAttack()
    {
        if (tTime > Time.time) return;
        player.anim.SetBool("smash", true);
        player.stopInAir();
        smash.smash();
        tTime = Time.time + cooldown;

    }
    private void resetValues()
    {
        player.anim.SetBool("throw", false);
        player.anim.SetBool("attack", false);
        player.anim.SetBool("smash", false);
        facing = 1;
    }
}
