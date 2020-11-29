using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    [SerializeField] AudioClip cannonSound;

    Animator animator;
    GameObject projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start() 
    {
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }
    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        AudioSource.PlayClipAtPoint(cannonSound, transform.position);
        GameObject newProjectile = Instantiate(
            projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
