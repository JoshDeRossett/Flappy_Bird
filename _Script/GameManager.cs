using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public GameObject gameOverRoot;
    public GameObject titleRoot;
    public GameObject restartGame;
    public Text scoreText;
    public Text highScoreText;
    public static bool move = false;
    public static bool isDead;
    public static int score = 0;
    public static int stageNumber = 0;
    public static int difficulty = 1;
    public static float piperange = 0;
    private void Start () {
        IsAlive();
        UpdateScore();
    }
    public void StartGame() {
        move = true;
        score = 0;
        titleRoot.SetActive(false);
    }
    private void IsDead() {
        gameOverRoot.SetActive(true);
        restartGame.SetActive(true);
    }
    private void IsAlive() {
        gameOverRoot.SetActive(false);
        restartGame.SetActive(false);
        isDead = false;
    }
    private void Update() {
        UpdateScore();
        stageNumber = score < 10 ? 0 : score < 20 ? 1 : 2;
        difficulty = stageNumber < 1 ? 1 : stageNumber < 2 ? 2 : 3;
        piperange = stageNumber < 1 ? Random.Range(-1.5f, 0.5f) : stageNumber < 2 ? Random.Range(-1.5f, 1.0f) : Random.Range(-1.5f, 1.5f);
        if (isDead == true) IsDead();
    }
    private void Highscore(int newHighScore) {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighScore > oldHighscore) PlayerPrefs.SetInt("highscore", newHighScore);
        PlayerPrefs.Save();
    }
    public void UpdateScore() {
        scoreText.text = "Score: " + score;
        Highscore(score);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highscore");
    }
}
