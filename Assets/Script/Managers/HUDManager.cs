using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    // private Vector3[] scoreTextPosition = {
    //     new Vector3(-747, 473, 0),
    //     new Vector3(0, 0, 0)
    //     };
    // private Vector3[] restartButtonPosition = {
    //     new Vector3(844, 455, 0),
    //     new Vector3(0, -150, 0)
    // };

    public GameObject scoreText;
    public GameObject scoreText2;

    // public Transform restartButton;


    public GameObject inGameScene;
    public GameObject gameOverScene;
    public GameObject Enemy1;
    public GameObject Enemy2;

    public GameObject highscoreText;
    public IntVariable gameScore;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Awake()
    {

        GameManager.Instance.gameStart.AddListener(GameStart);
        GameManager.Instance.gameOver.AddListener(GameOver);
        GameManager.Instance.gameRestart.AddListener(GameStart);
        GameManager.Instance.scoreChange.AddListener(SetScore1);

    }


    public void GameStart()
    {
        // hide gameover panel
        gameOverScene.SetActive(false);
        inGameScene.SetActive(true);
        Enemy1.SetActive(true);
        Enemy2.SetActive(true);
        Debug.Log("test1");

    }

    public void SetScore1(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        scoreText2.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }


    public void GameOver()
    {
        gameOverScene.SetActive(true);
        inGameScene.SetActive(false);
        Debug.Log("test");
        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }
}
