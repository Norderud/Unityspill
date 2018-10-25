using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======
using System;
>>>>>>> 9c3da05aff388ad4392a616aea7d9e4b6d1b25c1

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
        if (isHit && Time.time - startTime > duration) {
            isHit = false;
            startTime = 0;
        }
        gameObject.GetComponent<Animator>().SetBool("IsHit", isHit);
    }

    public void TakeDmg(int dmg) {
        health -= dmg;
        startTime = Time.time;
        isHit = true;
<<<<<<< HEAD
        if (gameObject.tag == "Glenn") {
            FindObjectOfType<AudioManager>().Play("Dmg");
            Random rnd = new Random();
            string[] sound = {"Dmg", "Dmg2", "Dmg3"};
            FindObjectOfType<AudioManager>().Play("Dmg");
=======
        if (gameObject.tag == "Glenn")
        {
            System.Random rnd = new System.Random();
            int s = rnd.Next(0,3);
                    
            string[] sound = {"Dmg", "Dmg2", "Dmg3"};
            FindObjectOfType<AudioManager>().Play(sound[s]);
>>>>>>> 9c3da05aff388ad4392a616aea7d9e4b6d1b25c1
        }
    }
}
