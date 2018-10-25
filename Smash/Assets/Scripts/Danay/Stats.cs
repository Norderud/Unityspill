using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Random;

public class Stats : MonoBehaviour {

    public int health = 100;
    public bool dead = false;
    public bool isHit;

    private float startTime;
    private float duration = 0.7f;


    // Use this for initialization
    void Start () {
     
	}

    // Update is called once per frame

	void Update () {
        if (health <= 0) {
            dead = true;
        }
        if (isHit && Time.time - startTime > duration)
            isHit = false;
    }

    public void TakeDmg(int dmg) {
        health -= dmg;
        startTime = Time.time;
        isHit = true;
        if (gameObject.tag == "Glenn")
        {
            Random rnd = new Random();
         
            string[] sound = {"Dmg", "Dmg2", "Dmg3"};            FindObjectOfType<AudioManager>().Play("Dmg");
        }
    }

   

}
