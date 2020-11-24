using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    bool DoorIsOpen = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if (DoorIsOpen) {
            FindObjectOfType<Player>().GoThroughDoor();
            GetComponent<Animator>().SetTrigger("OpenDoor");
            StartCoroutine(loadNextScene());
        }
        
    }

    IEnumerator loadNextScene() {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void OpenDoor() {
        DoorIsOpen = true;
    }
}
