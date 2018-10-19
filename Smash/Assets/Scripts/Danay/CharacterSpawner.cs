using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] players;

	// Use this for initialization
	void Start () {
        int player1 = PlayerPrefs.GetInt("Player1");
        int player2 = PlayerPrefs.GetInt("Player2");

        PlayerPrefs.SetString("Player2tag", players[player2].tag);

        if (players != null) {
            Instantiate(players[player1], Vector2.zero, Quaternion.identity);
            Instantiate(players[player2], Vector2.zero, Quaternion.identity);
        }
    }

}
