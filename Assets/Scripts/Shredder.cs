using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag != "Ground") {
            Destroy(collider.gameObject);
        }
    }
}
