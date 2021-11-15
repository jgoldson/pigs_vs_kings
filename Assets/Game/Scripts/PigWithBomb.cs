using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigWithBomb : MonoBehaviour
{
    Animator animator;
    [SerializeField] float timeUntilThrow = 2;
    [SerializeField] Vector2 bombThrowSpeed = new Vector2 (-5, 5);
    [SerializeField] GameObject projectile, gun;
    float timeLeftBeforeThrow;
    // Start is called before the first frame update
    void Start()
    {
        timeLeftBeforeThrow = timeUntilThrow;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftBeforeThrow -= Time.deltaTime;
        if (timeLeftBeforeThrow <= 0){
            animator.SetTrigger("ThrowBomb");
            timeLeftBeforeThrow = timeUntilThrow; 
        }
    }

    public void Fire() {
        //AudioSource.PlayClipAtPoint(cannonSound, transform.position);
        GameObject newProjectile = Instantiate(
            projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = gameObject.transform;
        newProjectile.GetComponent<Rigidbody2D>().velocity = bombThrowSpeed;
    }

}
