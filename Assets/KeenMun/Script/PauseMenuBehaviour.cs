using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenuBehaviour : MainMenuBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameWinMenu;
    public AudioSource GameplayMusic;
    public AudioSource GameOverMusic;
    public AudioSource GameWinMusic;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        GameplayMusic.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameplayMusic.UnPause();
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverMenu.gameObject.SetActive(true);
        GameplayMusic.Stop();
        GameOverMusic.Play();        
    }

    public void GameWin()
    {
        gameWinMenu.gameObject.SetActive(true);
        GameplayMusic.Stop();
        GameWinMusic.Play();
    }
}
