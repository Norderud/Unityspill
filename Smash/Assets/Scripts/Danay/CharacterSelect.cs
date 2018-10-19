using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

    public Text title;

    private int playerSelect = 0;

	public void ChooseCharacter(int charIndex) {
        if (playerSelect > 1) return;
        PlayerPrefs.SetInt("Player" + (playerSelect+1), charIndex);
        print("Player" + (playerSelect + 1));
        playerSelect++;
        if (playerSelect == 1)
            title.text = "Player 2";
    }

    public void LoadScene() {
        SceneManager.LoadScene("Danay");
    }
}
