using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    [SerializeField] AudioClip cannonSound;

    Animator animator;
    GameObject projectileParent;


    private void Start() 
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        AudioSource.PlayClipAtPoint(cannonSound, transform.position);
        GameObject newProjectile = Instantiate(
            projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = gameObject.transform;
    }

    public float CannonDirection() {
        return Mathf.Sign(gameObject.transform.localScale.x);
    }
}
