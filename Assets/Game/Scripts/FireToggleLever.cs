using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToggleLever : MonoBehaviour
{

    [SerializeField] AudioClip fireToggleSound;
    [SerializeField] FireTrap fireTrapToToggle;
    
    private void OnTriggerEnter2D(Collider2D other) {
        AudioSource.PlayClipAtPoint(fireToggleSound, Camera.main.transform.position);
        fireTrapToToggle.TurnOffFire();
        GetComponent<Animator>().SetBool("Pulled", true);
    }
}
