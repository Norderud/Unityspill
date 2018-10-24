using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour {
    public Collider2D col;
    public float attackDuration;

    private bool dir = true;
    private float attackStart;

    private void Start()
    {
        col.enabled = false;
    }
    private void Update()
    {
        
    }
    internal void kick()
    {
        attackStart = Time.time;

    }
    public void moveCollider(int facing)
    {
        if (facing > 0)
        {
            if (!dir)
            {
                col.transform.position = new Vector2(col.transform.position.x + 2.5f, col.transform.position.y);
                dir = true;
            }
        }
        else
        {
            if (dir)
            {
                col.transform.position = new Vector2(col.transform.position.x - 2.5f, col.transform.position.y);
                dir = false;
            }
        }
    }
}
