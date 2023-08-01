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
    public int answerOffSet;
    public float spawnInterval;
    public GameObject questText;

    private float timer = 0.0f;

    private int a;
    private int b;
    private int answer;
    private int wrongAnswer;
    

    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestionAndOptions();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            timer = 0.0f;
            GenerateQuestionAndOptions();
        }
    }

    void GenerateQuestionAndOptions() //a + b = answer
    {
        int randomForQuestion = Random.Range(1, 3);

        if(randomForQuestion <= 1) //addition
        {
            answer = Random.Range(minNumber, maxNumber);
            a = Random.Range(minNumber, answer);
            b = answer - a;

            wrongAnswer = Random.Range(answer + answerOffSet, answer - answerOffSet);
            questText.GetComponent<TextMeshProUGUI>().text = a + " + " + b + " = ? ";      //question generation

            Debug.Log(a + " + " + b + " = " + answer + " wrong answer is " + wrongAnswer);
        }

        if (randomForQuestion >= 2) //subtraction
        {
            a = Random.Range(minNumber, maxNumber);
            answer = Random.Range(minNumber, a);
            b = a - answer;

            wrongAnswer = Random.Range(answer + answerOffSet, answer - answerOffSet);
            questText.GetComponent<TextMeshProUGUI>().text = a + " - " + b + " = ? ";      //question generation      
            
            Debug.Log(a + " - " + b + " = " + answer + " wrong answer is " + wrongAnswer);
        }

        var spawnedOptions = Instantiate(options, spawnPoint.position, spawnPoint.rotation);
        int randomForOptions = Random.Range(1, 3);

        if(randomForOptions <= 1) // right, wrong
        {
            spawnedOptions.transform.Find("Option One/Canvas/Option A Text").GetComponent<TextMeshProUGUI>().text = answer.ToString();
            spawnedOptions.transform.Find("Option Two/Canvas/Option B Text").GetComponent<TextMeshProUGUI>().text = wrongAnswer.ToString();
            spawnedOptions.transform.Find("Option Two").GetComponent<WrongAnswer>().IsWrong = true;
        }

        if (randomForOptions >= 2) // wrong, right
        {
            spawnedOptions.transform.Find("Option One/Canvas/Option A Text").GetComponent<TextMeshProUGUI>().text = wrongAnswer.ToString();
            spawnedOptions.transform.Find("Option Two/Canvas/Option B Text").GetComponent<TextMeshProUGUI>().text = answer.ToString();
            spawnedOptions.transform.Find("Option One").GetComponent<WrongAnswer>().IsWrong = true;
        }
    }
}
