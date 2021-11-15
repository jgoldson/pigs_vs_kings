using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondPickup : MonoBehaviour
{

    [SerializeField] int pointValue = 100;
    [SerializeField] AudioClip diamondPickupSFX;

    GameSession gameSession;

    private void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        AudioSource.PlayClipAtPoint(diamondPickupSFX, Camera.main.transform.position);
        gameObject.SetActive(false);
        Debug.Log("Adding points for diamond");
        gameSession = FindObjectOfType<GameSession>();
        gameSession.AddToScore(pointValue);
        Destroy(gameObject, 1);
    }
}
