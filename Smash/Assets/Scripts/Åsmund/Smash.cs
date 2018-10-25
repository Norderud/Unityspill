using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour {
    public GameObject smash_ground;
    public Collider2D col;
    public float smashDuration;

    private float smashStart;

    // Use this for initialization
    void Start () {
        col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - smashStart > smashDuration)
            col.enabled = false;
	}
    public void smash()
    {
        smashStart = Time.time;
        col.enabled = true;
        //Destroy(Instantiate(smash_ground, gameObject.transform.position, Quaternion.identity), 1f);

    }
}
