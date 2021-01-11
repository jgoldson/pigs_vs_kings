using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float timeUntilExplode = 3;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilExplode -= Time.deltaTime;
        if (timeUntilExplode <= 0){
            animator.SetTrigger("BombExplode");
            
        }
    }
    public void DestroyBomb(){
        Destroy(gameObject);
    }
    public void Explosion(){
        this.gameObject.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = true;
    }
}
