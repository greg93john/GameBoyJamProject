using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeep : MonoBehaviour {
    // public variables
    public int scorePerSecond;

    // privae variables
    private Text scoreDisplay;
    private GameObject player;
    private bool playing;
    static private int scoreAmount, highScore;


    // Use this for initialization
    void Start () {
        InitializeVariables();
	}
	
	// Update is called once per frame
	void Update () {

        playing = player;

        if (playing) {
            AddToScore(scorePerSecond);
            scoreDisplay.text = "Score: " + scoreAmount.ToString();
        }
	}

    public void AddToScore(int score) {
        scoreAmount += score;
    }

    public static int GetScore() {
        return scoreAmount;
    }

    private void InitializeVariables() {
        scoreDisplay = GetComponent<Text>();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        scoreAmount = 0;
        highScore = PlayerPrefsManager.GetHighScore();
    }
}
