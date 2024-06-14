using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject P1WinsButton;
    public GameObject P2WinsButton;

    void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.score1 == GameManager.instance.ScoreMax)
            {
                P1WinsButton.SetActive(true);
                P2WinsButton.SetActive(false);
            }
            else if (GameManager.score2 == GameManager.instance.ScoreMax)
            {
                P1WinsButton.SetActive(false);
                P2WinsButton.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}