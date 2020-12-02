using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
[SerializeField] AudioClip keyPickupSFX;

private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log(Camera.main);
    AudioSource.PlayClipAtPoint(keyPickupSFX, transform.position);
    FindObjectOfType<LevelExit>().OpenDoor();
    Destroy(gameObject);

}

}
