using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] bool FollowPlayer = true;
    [SerializeField] GameObject birdsDialogue;

    Cage cage;
    Player player;
    float xDistanceToFollow = 0.8f;
    float yDistanceToFollow = 0.3f;
    float timeToChangeDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToChangeDistance -= Time.deltaTime;
        if (timeToChangeDistance < 0f) {
            xDistanceToFollow = Random.Range(0.7f, 0.9f);
            yDistanceToFollow = Random.Range(0.2f, 0.4f);
            timeToChangeDistance = Random.Range(2f, 4f);
        }
        if (FollowPlayer) {
        Vector2 playerPos = player.transform.position;
        float playerDirection = player.transform.localScale.x;
        gameObject.transform.position = new Vector2(playerPos.x + (-xDistanceToFollow * playerDirection), playerPos.y + yDistanceToFollow);
        gameObject.transform.localScale = new Vector2 (-playerDirection, 1f); 
        }
    }

    public void toggleFollowPlayer(){
        FollowPlayer = !FollowPlayer;
    }
    public void ActivateDialogue(){
        birdsDialogue.SetActive(true);
        OpenCage();
    }

    public void OpenCage() {
        
        Cage cage = FindObjectOfType<Cage>();
        if (cage) {
            cage.Open();
        }
    }
}

