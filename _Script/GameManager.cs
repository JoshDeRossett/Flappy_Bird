using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverRoot;
    public GameObject titleRoot;
    public Text scoreText;
    public Text highScoreText;
    private bool gameStarted;
    private float levelSpeed;
    public static float move = 0;
    public static int score;
    public static int currentscore;
    public static int stageNumber;
    private int currentstage;
    private void Start () {
        gameOverRoot.SetActive(false);
        currentscore = 0;
        score = 0;
        UpdateScore();
        print("Stage Number: " + stageNumber);
    }
    void Update() {
        if (currentscore > score | currentscore < score) {
            score = currentscore;
            UpdateScore();
        }
        currentstage = score < 10 ? 0 : score < 20 ? 1 : 2;
        if (currentstage > stageNumber | currentstage < stageNumber)
        {
            stageNumber = currentstage;
            print("Stage Number: " + stageNumber);
        }
    }
    void Highscore(int newHighScore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighScore > oldHighscore) 
            PlayerPrefs.SetInt("highscore", newHighScore);
        PlayerPrefs.Save();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        Highscore(score);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highscore");
    }
    public void StartGame () {
        move = 1;
        titleRoot.SetActive(false);
    }
}
