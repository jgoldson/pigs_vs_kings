using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingLarry : MonoBehaviour
{
    Cage cage;
    public void KingOutro() {
        GetComponent<Animator>().SetTrigger("KingLeaves");
    }
    public void OpenCage() {
        
        Cage cage = FindObjectOfType<Cage>();
        if (cage) {
            cage.Open();
        }
    }

    public void OpenDoor() {
        FindObjectOfType<LevelExit>().GetComponent<Animator>().SetTrigger("OpenDoor");
    }
    public void DestroyKing() {
        Destroy(gameObject);
    }
}
