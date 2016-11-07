using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    
    // public variables

    // private variables
    private PlayerController player;
    private float offsetX;

    // Use this for initialization
    void Start () {
        player = GameObject.FindObjectOfType<PlayerController>();
        offsetX = transform.position.x - player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (player) {
            transform.position = new Vector3(player.transform.position.x + offsetX, transform.position.y, transform.position.z);
        } else { FindPlayer(); }
    }

    void FindPlayer() {
        player = GameObject.FindObjectOfType<PlayerController>();
    }
}
