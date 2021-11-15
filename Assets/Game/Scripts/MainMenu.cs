using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] bool newGame = false;
    GameSession gameSession;
    int savedLevel;

private void Start() {
    gameSession = FindObjectOfType<GameSession>();
}
    private void OnTriggerEnter2D(Collider2D other) {
            FindObjectOfType<Player>().GoThroughDoor();
            GetComponent<Animator>().SetTrigger("OpenDoor");
            StartCoroutine(loadNextScene());
    }

    IEnumerator loadNextScene() {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(3);
        if (newGame) {
            PlayerPrefs.DeleteAll();
        }
        SceneManager.LoadScene(GetSavedLevel());
    }


private int GetSavedLevel() {
    if (PlayerPrefs.HasKey("SavedLevel"))
	{
		savedLevel = PlayerPrefs.GetInt("SavedLevel");
        gameSession.LoadGameStats();
		Debug.Log("Game data loaded!");
	}
	else
        savedLevel = 1;
		Debug.Log("There is no save data!");

    return savedLevel;
}
}
