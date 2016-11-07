using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Position : MonoBehaviour { 

    public void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
