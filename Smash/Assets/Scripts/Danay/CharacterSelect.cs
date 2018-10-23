using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

    public Text title;

    private int playerSelect = 0;

    private void Start() {
        // Resets playerprefs
        PlayerPrefs.DeleteKey("Player1");
        PlayerPrefs.DeleteKey("Player2");
    }

    public void ChooseCharacter(int charIndex) {
        // Limitations
        if (playerSelect != 0 && 
                PlayerPrefs.GetInt("Player" + (playerSelect)) == charIndex) return;
        if (playerSelect > 1) return;

        PlayerPrefs.SetInt("Player" + (playerSelect+1), charIndex); // Player pref variable for player1/player2
        playerSelect++; //Next player
        if (playerSelect < 2)
            title.text = "Player " + (playerSelect + 1) + " - Choose your character";
        else if (playerSelect == 2) // All players have chosen
            title.text = "Press start to play";
    }

    // Goes back once in character select screen
    public void Back() {
        if (playerSelect < 1) return;   //Limitation
        playerSelect--;
        title.text = "Player " + (playerSelect + 1) + " - Choose your character";
    }

    // Loads the game scene
    public void LoadScene() {
        if (playerSelect == 2)
            SceneManager.LoadScene("Danay");
    }
}
