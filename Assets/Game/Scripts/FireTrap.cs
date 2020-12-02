using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public void TurnOffFire() {
        foreach ( Transform child in transform) {
            child.GetComponent<Animator>().SetBool("FireIsOn", false);
            child.gameObject.layer = LayerMask.NameToLayer("Ground");
            child.GetComponent<CapsuleCollider2D>().enabled = false;
        }
       
    }
}
