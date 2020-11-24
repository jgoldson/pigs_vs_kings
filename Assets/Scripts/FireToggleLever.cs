using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToggleLever : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D other) {
    FindObjectOfType<FireTrap>().TurnOffFire();
    GetComponent<Animator>().SetBool("Pulled", true);
}
}
