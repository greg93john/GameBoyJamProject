using UnityEngine;
using System.Collections;

public class JumpToNextScene : MonoBehaviour {
    LevelManager levelManager;
	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadNextLevel();
	}
}
