using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // events
    public UnityEvent gameStart;
    public UnityEvent gameRestart;
    public UnityEvent<int> scoreChange;
    public UnityEvent gameOver;
    public UnityEvent changeUI;
    // private int score = 0;

    public IntVariable gameScore;

    // use it as per normal

    void Start()
    {
        gameStart.Invoke();
        Time.timeScale = 1.0f;
        // subscribe to scene manager scene change
        SceneManager.activeSceneChanged += SceneSetup;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneSetup(Scene current, Scene next)
    {
        gameStart.Invoke();
        // SetScore(score);
        scoreChange.Invoke(gameScore.Value);
    }

    public void GameRestart()
    {
        // reset score
        // score = 0;
        // SetScore(score);
        gameScore.Value = 0;
        scoreChange.Invoke(gameScore.Value);
        gameRestart.Invoke();
        Time.timeScale = 1.0f;
        // reset score

    }

    public void IncreaseScore(int increment)
    {
        // score += increment;
        // SetScore(score);
        scoreChange.Invoke(gameScore.Value);
        // increase score by 1
        gameScore.ApplyChange(1);
    }

    public void SetScore(int score)
    {
        //scoreChange.Invoke(score);
        // invoke score change event with current score to update HUD
        scoreChange.Invoke(gameScore.Value);
    }


    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.Invoke();
    }
    public void UpdateUI()
    {
        changeUI.Invoke();
    }
}