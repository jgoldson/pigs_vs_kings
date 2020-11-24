using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondPickup : MonoBehaviour
{

    [SerializeField] int pointValue = 100;

    GameSession gameSession;

    private void Start() {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        gameSession.AddToScore(pointValue);
    }
}
