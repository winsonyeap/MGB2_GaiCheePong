using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public bool IsWrong = false;
    private GameObject gc;
    public GameController gcScript;
    public bool gameOver = false;
    public GameObject otherOption;
    public PauseMenuBehaviour pauseMenuBehavior; //JokeChu script

    public GameObject Explosion;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("Game Controller");
        gcScript = gc.GetComponent<GameController>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gcScript.limited && IsWrong && other.CompareTag("Player"))
        {
            gameOver = true;
            otherOption.GetComponent<WrongAnswer>().gameOver = true;
            var spawn= Instantiate(Explosion, other.transform.position, other.transform.rotation);
            spawn.GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
            FindObjectOfType<PauseMenuBehaviour>().GameOver(); //JokeChu function
        }

        if (gcScript.limited && gcScript.numOfQuestions == gcScript.numOfQuestionsAsked && other.CompareTag("Player") && !IsWrong && !gameOver)
        {
            Time.timeScale = 0;
            FindObjectOfType<PauseMenuBehaviour>().GameWin(); //JokeChu function
            // level complete when collide with correct answer
        }

        if (!gcScript.limited && IsWrong && other.CompareTag("Player"))
        {
            Time.timeScale = 0;          
            Debug.Log("done");       
            //game over when collide with wrong answer
        }
       
    } 
}
