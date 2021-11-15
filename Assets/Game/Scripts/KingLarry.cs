using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingLarry : MonoBehaviour
{
    [SerializeField] Bird birdFriend;
    
    public void KingOutro() {
        GetComponent<Animator>().SetTrigger("KingLeaves");
    }

    public void OpenDoor() {
        FindObjectOfType<LevelExit>().GetComponent<Animator>().SetTrigger("OpenDoor");
        
    }
    public void DestroyKing() {
        FindObjectOfType<Bird>().GetComponent<Animator>().SetTrigger("IntroScene");
        Destroy(gameObject);

        
    }
}
