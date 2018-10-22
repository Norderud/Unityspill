using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] players;

    public GameObject p1, p2;

	// Use this for initialization
	void Start () {
        int player1 = PlayerPrefs.GetInt("Player1");
        int player2 = PlayerPrefs.GetInt("Player2");

        PlayerPrefs.SetString("Player2tag", players[player2].tag);

        if (players != null) {
            p1 = Instantiate(players[player1], Vector2.zero, Quaternion.identity);
            p2 = Instantiate(players[player2], Vector2.zero, Quaternion.identity);
        }
    }

    public void EnablePlayers(bool enable) {
        switch (p1.tag) {
            case ("Åsmund"):
                p1.GetComponent<Player_Controller>().enabled = enable;
                break;
            case ("Glenn"):
                p1.GetComponent<Movement>().enabled = enable;
                break;
            case ("Danay"):
                p1.GetComponent<Controller>().enabled = enable;
                break;
        }
        switch (p2.tag) {
            case ("Åsmund"):
                p2.GetComponent<Player_Controller>().enabled = enable;
                break;
            case ("Glenn"):
                p2.GetComponent<Movement>().enabled = enable;
                break;
            case ("Danay"):
                p2.GetComponent<Controller>().enabled = enable;
                break;
        }
    }

    void Update() {
        //print(p2.GetComponent<Stats>().health);
    }

}
