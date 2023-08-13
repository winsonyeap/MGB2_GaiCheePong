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
        gc = GameObject.FindGameObjectWithTag("Game Controller");
        gcScript = gc.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gcScript.limited && gcScript.numOfQuestions == gcScript.numOfQuestionsAsked && other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            // level complete
        }

        if (gcScript.limited && IsWrong && other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            //level failed
        }

        if (!gcScript.limited && IsWrong && other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log("done");

            FindObjectOfType<PauseMenuBehaviour>().GameOver(); //JokeChu function
            
        }
       
    } 
}
