using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    
    public int health = 100;
    public bool dead = false;
  

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
     
	}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
=======
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
>>>>>>> 58162a71cdc2d0d0faae5d8777f824d7efed6b99
            dead = true;
        }
    }

    public void TakeDmg(int dmg) {
        health -= dmg;
    }

   

}
