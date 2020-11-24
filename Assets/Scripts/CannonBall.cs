using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject explosionPrefab;
    

    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject explosionParticles = Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity) as GameObject;
            Destroy(explosionParticles, 0.5f);

        Destroy(gameObject, 0.01f);

    }
}
