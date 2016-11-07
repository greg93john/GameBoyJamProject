using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

    // public variables
    public Transform barrelEnd, groundCheck;
    public LayerMask whatIsGround;
    public GameObject playerLaser;
    public float moveSpeed, jumpForce, jumpTimeMax, projectileSpeed;

    [Tooltip("Multiplier for how much faster you go after passing a certain milestone.")]
    public float moveSpeedMultiplier;
    [Tooltip("Distance that needs to be traveled before player speeds up.")]
    public float speedIncreaseMilestone;
    [Tooltip("The maximum speed a player can go.")]
    public float maxSpeedThreshold;

    // private variables
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private GameObject projectilesParent;
    private float jumpTimeCounter, speedMilestoneCount, groundCheckRadius;
    private bool grounded;

	// Use this for initialization
	void Start () {
        projectilesParent = GameObject.Find("Projectiles");
        if (!projectilesParent) {
            projectilesParent = new GameObject("Projectiles");
        }

        groundCheckRadius = 0.1f;
        speedMilestoneCount = speedIncreaseMilestone;

        ComponentInitializer();
        JumpCounterReset();
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);

        if(transform.position.x > speedMilestoneCount && moveSpeed < maxSpeedThreshold) {
            IncreaseSpeed();
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && grounded) {
            PlayerJump();
        } else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !grounded) {
            FireMethod();
        } else if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) && !grounded) {
            ReduceJumpCounter(jumpTimeMax + 1f);
        } else if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && jumpTimeCounter > 0) {
            PlayerJump();
            ReduceJumpCounter(Time.deltaTime);
        } else if (grounded) {
            JumpCounterReset();
        }

        PlayerAnimations();
    }

    void PlayerJump() {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
    }

    void PlayerAnimations() {
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    void FireMethod() {
        GameObject projectile = Instantiate(playerLaser, barrelEnd.position, barrelEnd.rotation) as GameObject;
        projectile.transform.parent = projectilesParent.transform;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileSpeed, 0, 0);
    }

    void ReduceJumpCounter(float counter) {
        jumpTimeCounter -= counter;
    }

    void JumpCounterReset() {
        jumpTimeCounter = jumpTimeMax;
    }

    void IncreaseSpeed() {
        speedMilestoneCount += speedIncreaseMilestone;
        speedIncreaseMilestone = speedIncreaseMilestone * moveSpeedMultiplier;

        moveSpeed *= moveSpeedMultiplier;
        projectileSpeed *= moveSpeedMultiplier;
        Mathf.Clamp(moveSpeed, 1f, maxSpeedThreshold);
    }

    public void Death() {
        Destroy(gameObject);
    }

    void ComponentInitializer() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
}
