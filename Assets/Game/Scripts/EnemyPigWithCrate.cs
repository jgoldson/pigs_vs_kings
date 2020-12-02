using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPigWithCrate : MonoBehaviour
{
    [SerializeField] GameObject crate, gun;
    [SerializeField] Vector2 crateThrowSpeed = new Vector2 (-5, 5);
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("ThrowCrate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowNewCrate() {
        GameObject newCrate = Instantiate(
            crate, gun.transform.position, transform.rotation) as GameObject;   
            newCrate.GetComponent<Rigidbody2D>().velocity = crateThrowSpeed;
            newCrate.layer = gameObject.layer;
    }

}
