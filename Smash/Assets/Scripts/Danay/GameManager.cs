using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameOver = false;

    public CharacterSpawner chars;
    public Text endText;
    public Button button;
    public Text buttontxt;
    private float slomoStart;
    private float slomoDur = 0.5f;  

    // Use this for initialization
    void Start() {
        chars.EnablePlayers(true);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update() {
        if ((chars.p1.GetComponent<Stats>().dead ||
                chars.p2.GetComponent<Stats>().dead) && !gameOver) {
            gameOver = true; 
            GameOver();
        }
        if (gameOver && Time.time - slomoStart > slomoDur)    // Freezes time after number of frames exceedes duration
            Time.timeScale = 0f;
    }

    public void GameOver() {
        chars.EnablePlayers(false);
        slomoStart = Time.time;
        Time.timeScale = 0.2f;
        string winner;
        if (chars.p2.GetComponent<Stats>().dead) {
            chars.p2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            winner = "1";
        }
        else {
            chars.p1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            winner = "2";
        }
        endText.text = "Player " + winner + " wins!";
        button.GetComponent<Image>().enabled = true;
        button.GetComponent<Button>().enabled = true;
        buttontxt.text = "Play Again";
    }

    public void LoadCharSelect() {
        SceneManager.LoadScene("CharacterSelect");
    }
}
