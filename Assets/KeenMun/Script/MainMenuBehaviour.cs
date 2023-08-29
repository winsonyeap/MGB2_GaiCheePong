using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuBehaviour : MonoBehaviour
{

    public GameObject RicardoRocket;
    public GameObject LoadingScene;
    public void LoadLevel(string levelName)
    {
        RicardoRocket.SetActive(false);
        LoadingScene.SetActive(true);

        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName) ; 

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
