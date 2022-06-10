using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMTest : MonoBehaviour
{
    public Text speedDisplay;

    public void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        speedDisplay.text = " " + PlaneCont.speed;

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GameOver()
    {
        Invoke("End", 0.25f);
    }

    private void End()
    {
        Replay();
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
