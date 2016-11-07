using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    // public variables
    public float backgroundSize, parallaxSpeed;
    public bool scrolling, parallax;

    // private variables
    private Transform cameraTransform;
    private Transform[] backgroundLayers;
    private float viewZone, lastCameraX;
    private int leftIndex, rightIndex;

	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        backgroundLayers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++) {
            backgroundLayers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = backgroundLayers.Length - 1;
	}

    // Update is called once per frame
    void Update() {
        if (parallax) {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCameraX = cameraTransform.position.x;

        if (scrolling) {
            if (cameraTransform.position.x < (backgroundLayers[leftIndex].position.x + viewZone)) {
                ScrollLeft();
            } else if (cameraTransform.position.x > (backgroundLayers[rightIndex].position.x - viewZone)) {
                ScrollRight();
            }
        }
	}

    private void ScrollLeft() {
        int lastRight = rightIndex;
        backgroundLayers[rightIndex].position = Vector3.right * (backgroundLayers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0) {
            rightIndex = backgroundLayers.Length - 1;
        }
    }

    private void ScrollRight() {
        int lastLeft = leftIndex;
        backgroundLayers[leftIndex].position = Vector3.right * (backgroundLayers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == backgroundLayers.Length) {
            leftIndex = 0;
        }
    }
}
