using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {
    static MusicManager instance;

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            Debug.Log("Don't destory on load: " + name);
            Debug.Log("Duplicate music player self-destructing!");
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    void Start () {
	}
	
	public void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Playing clip: " + thisLevelMusic);
		
		if (thisLevelMusic) { // If there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
            audioSource.Play();
            
		} else if (level == 4) { Debug.Log("Music Should stop now!"); audioSource.Stop(); }
    }
	
	public void SetVolume (float volume) {
		audioSource.volume = volume;
	}
}
