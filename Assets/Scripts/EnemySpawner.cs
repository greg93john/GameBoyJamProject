using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float spawnDelay;
    public GameObject enemyPrefab, emptySpace;

    private GameObject enemyTransformParent;

	// Use this for initialization
	void Start () {
        enemyTransformParent = GameObject.Find("Enemies");
        if (!enemyTransformParent) {
            enemyTransformParent = new GameObject("Enemies");
        }

        Invoke("SpawnEnemies", spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemies() {
        foreach(Transform child in transform) {
            if(Random.value < 0.5f) {
                GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.position, Quaternion.identity);
                enemy.transform.parent = enemyTransformParent.transform;
            } else {
                GameObject empty = (GameObject)Instantiate(emptySpace, child.position, Quaternion.identity);
                empty.transform.parent = enemyTransformParent.transform;
            }
        }

        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        if (player) {
            Invoke("SpawnEnemies", spawnDelay);
        }
    }
}
