using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public static bool GameIsPaused = false;
    

    public GameObject pauseMenuUi;
    public GameObject SettingsMenuUi;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel") && SettingsMenuUi.active == false)
        {
            Pause();
        }
	}


    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused =  true;
    }

    public void LoadSettings()

    {
        pauseMenuUi.SetActive(false);
        SettingsMenuUi.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CharacterSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
