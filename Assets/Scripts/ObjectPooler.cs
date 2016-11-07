using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    // public variables
    [Tooltip("size of array must be AT LEAST 1")]
    public GameObject[] pooledObjects;

    [Tooltip("cannot use interger less than 5")]
    public int pooledAmount;

    // private variables
    [Tooltip("Don't bother editing this. Made public for another script to access list.")]
    public GameObject[] poolList;


    void Awake() {
        GameObject itemParent = GameObject.Find("Platforms");
        if (!itemParent) {
            itemParent = new GameObject("Platforms");
        }

        poolList = new GameObject[pooledAmount];
        int x = 0;

        for (int i = 0; i < pooledAmount; i++) {
            if (x >= pooledObjects.Length) {
                x = 0;
            }

            poolList[i] = (GameObject)Instantiate(pooledObjects[x]);
            poolList[i].transform.parent = itemParent.transform;
            poolList[i].SetActive(false);
            x++;
        }

    }

    void Start () {

	}
	
	public GameObject GetPooledObject (int choice) {
        if (!poolList[choice].activeInHierarchy) {
            return poolList[choice];
        } else { return null; }
    }
}
