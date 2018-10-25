using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    
    public int health = 100;
    public bool dead = false;
  


	// Use this for initialization
	void Start () {
     
	}

    // Update is called once per frame

	void Update () {
        if (health <= 0) {

            dead = true;
        }
    }

    public void TakeDmg(int dmg) {
        health -= dmg;
    }

   

}
