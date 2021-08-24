using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLarry : MonoBehaviour
{
    float timeToAttack = 2f;
    [SerializeField] GameObject player;
    [SerializeField] int health = 5;
    [SerializeField] bool canMove = true;
    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed = 1f;
    PolygonCollider2D myHammerCollider;
    [SerializeField] AudioClip deathSound;
    [SerializeField] int pointsForKillingEnemy = 5000;
    bool takingDamage = false;
    float playerDirection = 1;
    [SerializeField] float distanceFromPlayerToChase = 2;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myHammerCollider =  GetComponent<PolygonCollider2D>();
        turnOffHammerCollider();
    }   
    private void Update() {
            FacePlayer();
            WatchForDamage();
            timeToAttack-= Time.deltaTime;
             if (timeToAttack < 0f) {
                if(Random.Range(0f,1f) > 0.2f){
                    StandardAttack();
                }
                else {
                    StopAndAttack();
                }
             }
            if (canMove){
                GetComponent<Animator>().SetBool("isRunning", true);
                if (Mathf.Abs(player.transform.position.x - transform.position.x) > distanceFromPlayerToChase ){
                    transform.position = Vector2.MoveTowards(transform.position,player.transform.position, moveSpeed*Time.deltaTime);
                }
                else if (IsFacingLeft()) {
                    
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
                } else {
                    
                    myRigidBody.velocity = new Vector2(moveSpeed, 0f);
                }
            } else {
                myRigidBody.velocity = new Vector2(0,0);
                GetComponent<Animator>().SetBool("isRunning", false);
        }
    }
    public void StandardAttack(){
                GetComponent<Animator>().SetTrigger("Attack");
                timeToAttack = Random.Range(0.5f, 2f);
                canMove = true;
    }
    public void StopAndAttack(){
                GetComponent<Animator>().SetTrigger("Attack");
                timeToAttack = 4f;
                canMove = false;
    }
    
    private void FacePlayer(){
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > distanceFromPlayerToChase ){
    if(player.transform.position.x > transform.position.x){
     //face right
     transform.localScale = new Vector3(1,1,1);
     
     }else if(player.transform.position.x < transform.position.x){
     //face left
     transform.localScale = new Vector3(-1,1,1);
     
     }
        }


        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        print(other.CompareTag("Wall"));
        print(other.tag);
        if (other.CompareTag("Wall")){
            print("Touching Wall");
            transform.localScale  = new Vector3 (-transform.localScale.x, 1, 1);
        }
    }

    
    private bool IsFacingLeft() {
        return transform.localScale.x < 0;
    }
    public void StopMovement() {
        canMove = false;
    }
    public void turnOnHammerCollider(){
        myHammerCollider.enabled = true;
    }
    public void turnOffHammerCollider(){
        myHammerCollider.enabled = false;
    }

    private void WatchForDamage() {
        if (takingDamage){return;}
        if (myRigidBody.IsTouchingLayers(LayerMask.GetMask("EnemyHazard", "Hazards"))) {
            takingDamage = true;
           
           
           canMove = false;
            GetComponent<Animator>().SetTrigger("Hit");
            
            StartCoroutine(takeDamage());

        }
        
     }
     IEnumerator takeDamage(){
         
         yield return new WaitForSeconds(1);
         health -= 1;
        if (health <= 0) {
                BossDies();
            }
         canMove = true;
         takingDamage = false;
     }
     public void BossDies(){
         FindObjectOfType<GameSession>().AddToScore(pointsForKillingEnemy);
         Destroy(gameObject);
     }
}
