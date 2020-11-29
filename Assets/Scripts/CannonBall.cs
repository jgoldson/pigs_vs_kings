using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] AudioClip boomSound;
    

    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        AudioSource.PlayClipAtPoint(boomSound, transform.position);
        GameObject explosionParticles = Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity) as GameObject;
            Destroy(explosionParticles, 0.5f);

        Destroy(gameObject, 0.01f);

    }
}
