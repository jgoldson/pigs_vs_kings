using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float timeUntilExplode = 3;
    [SerializeField] bool isLit = true;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLit)
        {
            timeUntilExplode -= Time.deltaTime;
            if (timeUntilExplode <= 0)
            {
                animator.SetTrigger("BombExplode");

            }
        }
    }
    public void DestroyBomb()
    {
        Destroy(gameObject);
    }
    public void Explosion()
    {
        gameObject.layer = 13;
        this.gameObject.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    public void bombNotLit(){
        isLit = false;
    }
    public void lightBomb(){
        isLit = true;
    }
}
