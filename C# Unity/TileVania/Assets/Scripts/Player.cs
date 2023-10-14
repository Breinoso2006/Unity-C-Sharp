using System.Diagnostics.Tracing;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5.8f;
    [SerializeField] float climbSpeed = 3f;
    [SerializeField] AudioClip deathSound;

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D mybodyCollider;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mybodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    void Update()
    {
        if (!isAlive) { return; }

        Run();
        FlipSprite();
        Jump();
        Climb();
        Die();

    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // de -1 a +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        bool isTouchingGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (CrossPlatformInputManager.GetButtonDown("Jump") && isTouchingGround)
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void Climb()
    {
        bool isPlayerTouchingStairs = myFeet.IsTouchingLayers(LayerMask.GetMask("Stairs"));

        if (isPlayerTouchingStairs)
        {
            float stairsControl = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 playerInStairsVelocity = new Vector2(myRigidBody.velocity.x, stairsControl * climbSpeed);
            myRigidBody.velocity = playerInStairsVelocity;
            myAnimator.SetBool("Climbing", isPlayerTouchingStairs);
            myRigidBody.gravityScale = 0f;
        }
        else
        {
            myAnimator.SetBool("Climbing", isPlayerTouchingStairs); 
            myRigidBody.gravityScale = gravityScaleAtStart; 
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    private void Die()
    {
        bool isBodyTouchingEnemyOrHazard = mybodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy" , "Hazard"));
        bool isFeetTouchingEnemyOrHazardd = myFeet.IsTouchingLayers(LayerMask.GetMask("Enemy" , "Hazard"));

        if (isBodyTouchingEnemyOrHazard || isFeetTouchingEnemyOrHazardd)
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidBody.velocity = new Vector2(-myRigidBody.velocity.x, 10f);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
