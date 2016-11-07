using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string HIGHSCORE_KEY = "highscore_key";
    
    public static void SetHighScore (int score) {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
    }

    public static int GetHighScore() {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY);
    }

}
