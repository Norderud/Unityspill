using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver = false;

    public CharacterSpawner chars;

    // Use this for initialization
    void Start() {
        chars.EnablePlayers(true);
    }

    // Update is called once per frame
    void Update()
    {
        if ( chars.p1.GetComponent<Stats>().dead ||
                chars.p2.GetComponent<Stats>().dead) {
            gameOver = true;
            GameOver();
        }
    }

    public void GameOver() {
        chars.EnablePlayers(false);
    }
}
