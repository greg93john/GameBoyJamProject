using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTracker : MonoBehaviour {
    GameObject player;
    GameObject gameOverScreen;
    Text highScoreText;

    private int currentHighScore;
    bool end;

    

	// Use this for initialization
	void Start () {
        InitializeComponents();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!player && end) {
            gameOverScreen.SetActive(true);

            int currentScore = ScoreKeep.GetScore();

            if (currentHighScore < currentScore) {
                SetNewHighScore(currentScore);
            }

            string highestScore = currentHighScore.ToString();

            DisplayHighScore(highestScore);
            end = false;
        }
	}

    void InitializeComponents() {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        gameOverScreen = GameObject.Find("GameOver Text");
        highScoreText = gameOverScreen.transform.GetChild(0).gameObject.GetComponent<Text>();
        currentHighScore = PlayerPrefsManager.GetHighScore();
        gameOverScreen.SetActive(false);
        end = true;
    }

    void DisplayHighScore(string maxScore) {
        highScoreText.text = "High Score: " + maxScore;
    }

    void SetNewHighScore(int score) {
        PlayerPrefsManager.SetHighScore(score);
        currentHighScore = PlayerPrefsManager.GetHighScore();
    }

    void PlayerDied() {
        end = true;
    }
}
