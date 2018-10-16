using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour {

    public Transform flames;
    public Transform player;
    private int face;
   
	// Use this for initialization
	void Start () {
        flames.GetComponent<ParticleSystem>().enableEmission = false;
        
        
	}
	
	// Update is called once per frame
	void Update () {

        jetpack();

    }

    private void jetpack()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {
            face = 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            face = -1;
        }

        if (Input.GetButton("Jump"))
        {
          
            
           flames.GetComponent<ParticleSystem>().enableEmission = true;
           flames.position = new Vector2(player.position.x - 0, player.position.y + 1.5f);    
           

        }
        else
        {
            flames.GetComponent<ParticleSystem>().enableEmission = false;
        }

    }

}
