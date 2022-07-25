using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonToggleLever : MonoBehaviour
{

    [SerializeField] AudioClip cannonToggleSound;
    [SerializeField] Cannon cannonToToggle;
    
    private void OnTriggerEnter2D(Collider2D other) {
        AudioSource.PlayClipAtPoint(cannonToggleSound, Camera.main.transform.position);
        cannonToToggle.TurnOnCannon();
        GetComponent<Animator>().SetBool("Pulled", true);
    }
}
