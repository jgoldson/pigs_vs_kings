using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Dialogue : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.StopPlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
            player.AllowPlayerMovement();
            gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
    }
}
