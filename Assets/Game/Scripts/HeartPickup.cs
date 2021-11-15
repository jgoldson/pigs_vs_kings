using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
[SerializeField] AudioClip heartPickupSFX;

private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log(Camera.main);
    AudioSource.PlayClipAtPoint(heartPickupSFX, transform.position);
    FindObjectOfType<GameSession>().AddLife();
    Destroy(gameObject);

}

}
