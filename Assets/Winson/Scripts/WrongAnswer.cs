using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public bool IsWrong = false;

    public PauseMenuBehaviour pauseMenuBehavior; //JokeChu script
    private void OnTriggerEnter(Collider other)
    {
        if (IsWrong && other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log("done");

            FindObjectOfType<PauseMenuBehaviour>().GameOver(); //JokeChu function
            
        }
       
    } 
}
