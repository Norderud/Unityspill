using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkController : MonoBehaviour {

    public Controller script;
    private float timer = 50f;
	
	// Update is called once per frame
	void Update () {

        if (true) {
            if (script.enabled == false && timer > 0)
                timer--;
            else {
                script.enabled = true;
                timer = 50f;
            }
        }

    }
}

