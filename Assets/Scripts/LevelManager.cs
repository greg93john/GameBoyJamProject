using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadNextLevelDelay(float delay) {
        Invoke("LoadNextLevel", delay);
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
