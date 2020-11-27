using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] bool DoorIsOpen = false;
    [SerializeField] bool doorToStart = false;


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
        if (doorToStart) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

    }

    public void OpenDoor() {
        DoorIsOpen = true;
    }
}
