using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] int force_Needed_To_Break = 10;
    [SerializeField] GameObject[] cratePieces;
    [SerializeField] float max_Breaking_Velocity = 5f;
    [SerializeField] float min_Breaking_Velocity = 1f;
    [SerializeField] AudioClip breakSound;
    

    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if ( other.gameObject.layer == 9 || 
        other.gameObject.layer == 10 ||
        other.gameObject.layer == 12) 
        //Check if is colliding with ground (9), Player (10), Enemy(12)
        { 
            if (other.relativeVelocity.magnitude > force_Needed_To_Break) {
                foreach (GameObject cratePiece in cratePieces) {
                    AudioSource.PlayClipAtPoint(breakSound, transform.position);
                    GameObject newPiece = 
                        Instantiate(cratePiece, transform.position, transform.rotation) as GameObject;
                    newPiece.GetComponent<Rigidbody2D>().velocity = 
                    new Vector2(Random.Range(-max_Breaking_Velocity, max_Breaking_Velocity),
                        Random.Range(min_Breaking_Velocity, max_Breaking_Velocity));
                    Destroy(newPiece, 0.5f);
                }
                Destroy(gameObject);
            } else {
                gameObject.layer = 15;
            }
        }

    }


}

