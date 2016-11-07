using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    public float damage;

    public float GetDamage() {
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Health healthAmount = collider.gameObject.GetComponent<Health>();
        if (healthAmount) {
            
        }
    }
}
