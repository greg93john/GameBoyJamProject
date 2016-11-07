using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0) {
            Die();
        }
	}

    void Die() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        ProjectileScript projectile = collider.gameObject.GetComponent<ProjectileScript>();
        if (projectile) {
            health -= projectile.GetDamage();
            projectile.Hit();

            if(health <= 0) {
                Die();
            }
        }
    }
}
