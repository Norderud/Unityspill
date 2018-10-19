using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerController : MonoBehaviour {

    public Player_Controller script;
    private float timer = 50f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (script.enabled == false && timer > 0)
        {
            timer--;
        }
        else
        {
            script.enabled = true;
            timer = 50f;
        }
    }
}
