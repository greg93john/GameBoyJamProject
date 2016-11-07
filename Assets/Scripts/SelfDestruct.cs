using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("SelfDestroy", 2f);
	}

    void SelfDestroy() {
        Destroy(gameObject);
    }
}
