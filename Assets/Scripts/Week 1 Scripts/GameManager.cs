using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Text speedDisplay;
    public Text scoreDisplay;
    public Text scoreHighDisplay;

    public void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        speedDisplay.text = " " + PlaneCont.speed;
        scoreDisplay.text = " " + PlaneCont.score;
        scoreHighDisplay.text = " " + PlaneCont.scoreHigh;
    }

    public void GameOver()
    {
        Invoke("End", 0.25f);
    }

    private void End()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(2);
    }
}
