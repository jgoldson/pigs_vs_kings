using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D myBodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        myBodyCollider = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        WatchForDamage();
    }

    private void WatchForDamage() {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("EnemyHazard"))) {
           // GetComponent<Rigidbody2D>().velocity = deathKick;
           FindObjectOfType<EnemyMovement>().StopMovement();
            GetComponent<Animator>().SetTrigger("Die");
            
        }
     }

     public void Die() {
         Destroy(gameObject);
     }
}
