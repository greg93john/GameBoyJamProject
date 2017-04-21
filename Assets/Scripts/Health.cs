using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health;

	// Use this for initialization
	void Start () {
	
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
                var enemyGameObject = gameObject.GetComponent<EnemyBehaviour>();

                if (enemyGameObject) {
                    enemyGameObject.Die();
                } else {
                    Debug.Log("GameObject has Health Script, but is not an enemy.");
                }
            }
        }
    }
}
