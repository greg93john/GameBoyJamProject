using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

    // public variables
    [Tooltip("Spawn Marker should be a GameObject that's childed to the main camera.")]
    public Transform spawnMarker;
    public Transform maxHeightPoint;
    public float distanceBetweenMin, distanceBetweenMax;

    // private variables
    private float distanceBetweenPlatforms, minHeight, maxHeight;
    private float[] platformWidths;
    private int platformSelector;
    private GameObject chosenPlatform;
    private GameObject[] platforms;
    private ObjectPooler objectPool;

	// Use this for initialization
	void Start () {
        minHeight = transform.position.y;
        if (maxHeightPoint) {
            maxHeight = maxHeightPoint.position.y;
        } else { Debug.LogWarning("Warning: MaxHeightPoint GameObject not found."); }

        objectPool = GameObject.FindObjectOfType<ObjectPooler>().GetComponent<ObjectPooler>();
        platforms = new GameObject[objectPool.poolList.Length];
        platforms = objectPool.poolList;

        InitializePlatformWidthsArray();
        SelectNewPlatform();
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x < spawnMarker.position.x) {
            SpawnNewPlatform();
        }
	}

    void SpawnNewPlatform() {
        distanceBetweenPlatforms = Random.Range(distanceBetweenMin, distanceBetweenMax);
        float heightChange = Random.Range(minHeight, maxHeight);
        float shiftDistance = transform.position.x + platformWidths[platformSelector] + distanceBetweenPlatforms;

        transform.position = new Vector3(shiftDistance,heightChange,transform.position.z);

        chosenPlatform.transform.position = transform.position;
        chosenPlatform.SetActive(true);

        SelectNewPlatform();
    }

    void SelectNewPlatform() {
        platformSelector = Random.Range(0, platforms.Length - 1);
        chosenPlatform = objectPool.GetPooledObject(platformSelector);
        if (chosenPlatform == null) {
            SelectNewPlatform();
        }
    }

    void InitializePlatformWidthsArray() {
        platformWidths = new float[platforms.Length];

        for (int i = 0; i < platformWidths.Length; i++) {
            platformWidths[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
    }
}
