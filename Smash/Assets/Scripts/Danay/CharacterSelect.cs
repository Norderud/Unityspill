using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	public void ChooseCharacter(int charIndex) {
        PlayerPrefs.SetInt("SelectedCharacter", charIndex);
    }

    public void LoadScene() {
        SceneManager.LoadScene("Danay");
    }
}
