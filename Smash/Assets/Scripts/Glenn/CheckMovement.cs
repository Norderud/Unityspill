using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovement : MonoBehaviour {

    public Movement script;
    private float timer = 140f;
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
            timer = 140f;
        }
	}
}
