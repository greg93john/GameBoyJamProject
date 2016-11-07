using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

    // public variables

    // private variables
    private GameObject destructionMarker;

	// Use this for initialization
	void Start () {
        destructionMarker = GameObject.Find("PlatformDestructionMarker");

        if (!destructionMarker) {
            Debug.LogWarning("Warning, GameObject [PlatformDestructionMarker] not found.");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x < destructionMarker.transform.position.x) {
            DeactivatePlatform();
        }
	}

    void DeactivatePlatform() {
        gameObject.SetActive(false);
    }
}
