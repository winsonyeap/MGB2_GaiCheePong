using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public bool IsWrong = false;
    private GameObject gc;
    public GameController gcScript;

    public PauseMenuBehaviour pauseMenuBehavior; //JokeChu script

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
        gcScript = gc.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gcScript.limited && gcScript.numOfQuestions == gcScript.numOfQuestionsAsked && other.CompareTag("Player") && !IsWrong)
        {
            Time.timeScale = 0;
            FindObjectOfType<PauseMenuBehaviour>().GameWin(); //JokeChu function
            // level complete when collide with correct answer
        }

        if (gcScript.limited && IsWrong && other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            FindObjectOfType<PauseMenuBehaviour>().GameOver(); //JokeChu function
            //level failed when collide with wrong answer
        }

        if (!gcScript.limited && IsWrong && other.CompareTag("Player"))
        {
            Time.timeScale = 0;          
            Debug.Log("done");       
            //game over when collide with wrong answer
        }
       
    } 
}
