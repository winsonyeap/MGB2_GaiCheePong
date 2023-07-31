using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject question;
    public GameObject options;
    public int minNumber;
    public int maxNumber;
    public Transform spawnPoint;

    //private TextMeshPro quesTMP;
    //private TextMeshPro quesTMP;
    //private TextMeshPro quesTMP;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestionAndOptions();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            timer = 0.0f;
            GenerateQuestionAndOptions();
        }
    }

    void GenerateQuestionAndOptions() //a + b = answer
    {
        int random = Random.Range(1, 3);


        if(random <= 1) //addition
        {
            int answer = Random.Range(minNumber, maxNumber);
            int a = Random.Range(minNumber, answer);
            int b = answer - a;

            
            Debug.Log(a + " + " + b + " = " + answer);
        }

        if (random >= 2) //subtraction
        {
            int a = Random.Range(minNumber, maxNumber);
            int b = Random.Range(minNumber, a);
            int answer = a - b;

            Debug.Log(a + " - " + b + " = " + answer);
        }
       
    }
}
