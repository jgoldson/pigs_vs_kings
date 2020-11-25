using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] GameObject[] cratePieces;
    [SerializeField] float max_Breaking_Velocity = 5f;
    [SerializeField] float min_Breaking_Velocity = 1f;
    

    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void DestroyBox() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if ( other.gameObject.layer == 9) { //Check if is colliding with ground (layer 9)
            if (other.relativeVelocity.magnitude > 10) {
                Debug.Log("Crate explode!");
                Debug.Log(other.relativeVelocity.magnitude);
                Debug.Log(other.rigidbody.tag);
                foreach (GameObject cratePiece in cratePieces) {
                    GameObject newPiece = 
                        Instantiate(cratePiece, transform.position, transform.rotation) as GameObject;
                    newPiece.GetComponent<Rigidbody2D>().velocity = 
                    new Vector2(Random.Range(-max_Breaking_Velocity, max_Breaking_Velocity),
                        Random.Range(min_Breaking_Velocity, max_Breaking_Velocity));
                    Destroy(newPiece, 1f);
                }
                Destroy(gameObject);
            }
        }

    }


}

