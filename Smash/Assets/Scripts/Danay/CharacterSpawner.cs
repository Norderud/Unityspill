using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] players;

	// Use this for initialization
	void Start () {
        int charIndex = PlayerPrefs.GetInt("SelectedCharacter");
        if (players != null)
            Instantiate(players[charIndex], Vector2.zero, Quaternion.identity);
    }

}
