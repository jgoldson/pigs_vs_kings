using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //Config    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 8f;
    [SerializeField] float horizontalJumpModifier = -2f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] float spawnTimer = 3f;

    //State
    bool isAlive = true;
    
    //Cached References
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive){return;}

        Run();
        FlipSprite();
        Jump();
        Die();
    }

    private void Run() {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //Value is between -1 and +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
    }
    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }
    private void Jump() {
        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}

        if (CrossPlatformInputManager.GetButtonDown("Jump")){
            Vector2 jumpVelocityToAdd = new Vector2(horizontalJumpModifier, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }
    private void Die() {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards"))) {
            GetComponent<Rigidbody2D>().velocity = deathKick;
            isAlive = false;
            myAnimator.SetTrigger("Die");
            StartCoroutine(WaitForSpawn());
            

        }
    }
    IEnumerator WaitForSpawn() {
        yield return new WaitForSeconds(spawnTimer);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
    public void GoThroughDoor() {
        myRigidBody.velocity = new Vector2(0f, 0f);
        myAnimator.SetTrigger("GoThroughDoor");
        isAlive = false;
    }
}
