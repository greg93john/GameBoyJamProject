using UnityEngine;
using System.Collections;

public class GameplayStyle : MonoBehaviour {
    
    // public variables
    public enum GameStyle { running, acending, falling};
    public static GameStyle currentGameStyle;

	// Use this for initialization
	void Start () {
        currentGameStyle = GameStyle.running;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectGameStyle() {

    }
}
