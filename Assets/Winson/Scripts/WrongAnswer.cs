using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public bool IsWrong = false;  
    private void OnTriggerEnter(Collider other)
    {
        if (IsWrong && other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log("done");
        }
       
    }
}
