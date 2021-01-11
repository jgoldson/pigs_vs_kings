using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    [SerializeField] AudioClip cannonSound;
    [SerializeField] GameObject pigLightingCannon;

    Animator animator;
    GameObject projectileParent;


    private void Start() 
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!pigLightingCannon){
            animator.SetTrigger("Idle");
        }
    }

    public void Fire() {
        if (!pigLightingCannon){return;}
        AudioSource.PlayClipAtPoint(cannonSound, transform.position);
        GameObject newProjectile = Instantiate(
            projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = gameObject.transform;
    }

    public float CannonDirection() {
        return Mathf.Sign(gameObject.transform.localScale.x);
    }
}
