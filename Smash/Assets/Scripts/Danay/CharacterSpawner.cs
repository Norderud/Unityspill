using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] players;

	// Use this for initialization
	void Start () {
        int charInd = PlayerPrefs.GetInt("SelectedCharacter");
        Instantiate(players[charInd], Vector2.zero, Quaternion.identity);
    }

}
