using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class Manager : MonoBehaviour
{
    public GameObject GameOverPanel;
    bool isGameOver;
    public GameObject YouWinPanel;
    private WaveSpawner waveSpawner;
    private CheckWaves testWaves;
    private void Start()
    {
        GameOverPanel.SetActive(false);
        YouWinPanel.SetActive(false);
    }

    public void GameOver()
    {
        isGameOver = !isGameOver;
        if (isGameOver)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
       
    }
   
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
