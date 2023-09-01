using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenuBehaviour : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameWinMenu;
    public AudioSource GameplayMusic;
    public AudioSource GameOverMusic;
    public AudioSource GameWinMusic;
    public AudioSource ScoringSound;
    //public GameObject Rocket;
    public GameObject InactiveFlame;

    public GameObject LoadScene;

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
        GameOverMusic.Play();
        GameplayMusic.Stop();
        StartCoroutine(GameOverPause());
    }

    IEnumerator GameOverPause()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameWin()
    {
        StartCoroutine(WinMenuOpen());
    }

    IEnumerator WinMenuOpen()
    {
        yield return new WaitForSeconds(2.5f);

        gameWinMenu.gameObject.SetActive(true);
        GameplayMusic.Stop();
        GameWinMusic.Play();
        Time.timeScale = 0f;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string levelName)
    {
        LoadScene.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }

    public void ScoreSoundPlay()
    {
        ScoringSound.Play();
    }
}
