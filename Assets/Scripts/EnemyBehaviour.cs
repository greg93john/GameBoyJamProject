using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour {
    // public variables
    public float horizontalSpeed, verticalSpeed;
    public AudioClip deathSound;
    public LayerMask whatIsGround;
    public GameObject explosionEffect;

    // private variables
    private bool grounded;
    private PlayerController player;
    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;
    private Health myHealth;
    private Color explosionColor;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<PlayerController>();
        ComponentInitializer();
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (!grounded) {
            horizontalSpeed = player.moveSpeed / 1.25f;
            HorizontalMovement(horizontalSpeed);
            VerticalMovement(verticalSpeed);
        } else { StopMoment(); }
	}

    void StopMoment() {
        myRigidbody.velocity = new Vector2(0f, 0f);
    }

    void HorizontalMovement(float move) {
        myRigidbody.velocity = new Vector2(move, myRigidbody.velocity.y);
    }

    void VerticalMovement(float move) {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, move);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            player.Death();
        }
    }

    void ComponentInitializer() {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myHealth = GetComponent<Health>();
    }

    void MakeExplosionEffect() {
        GameObject explosion = (GameObject)Instantiate(explosionEffect);
        explosion.transform.position = transform.position;
    }

    public void Die() {
        AudioSource.PlayClipAtPoint(deathSound,transform.position);
        MakeExplosionEffect();
        Destroy(gameObject);
    }
}
