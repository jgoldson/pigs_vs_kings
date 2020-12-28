using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;

    [SerializeField] Text scoreText;


    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddToScore(int amount) {
        score += amount;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessPlayerDeath() {

        if (playerLives > 1) 
        {
            TakeLife();
        }
        else {
            ResetGameSession();
        }
    }

    private void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    private void TakeLife() {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        UpdateHeartBar();
    }

    private void UpdateHeartBar() {
        switch (playerLives) {
            case 1:
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
            case 2:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
                break;
            default:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                break;
        }
    }
    public int GetLives(){
        return playerLives;
    }
    public int GetScore(){
        return score;
    }
    public void SetLives(int savedLives){
        playerLives = savedLives;
        UpdateHeartBar();
    }
    public void SetScore(int savedScore){
        score = savedScore;
        scoreText.text = score.ToString();
    }
    public void LoadGameStats(){
        score = PlayerPrefs.GetInt("SavedScore");
        scoreText.text = score.ToString();
        playerLives = PlayerPrefs.GetInt("SavedLives");
        UpdateHeartBar();
    }

}
