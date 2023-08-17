using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public bool subtraction = false; // if true, this level has subtraction questions
    public bool limited = true; // if true, this level has limited number of questions
    public int numOfQuestions; // number of questions if limited
    public int numOfQuestionsAsked = 0;

    private float timer = 0.0f;

    private int a;
    private int b;
    private int answer;
    private int wrongAnswer;

    //JokeChu stuff
    public GameObject questionPanel;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval && limited && numOfQuestionsAsked < numOfQuestions)
        {
            timer = 0.0f;
            GenerateQuestionAndOptions();
            numOfQuestionsAsked++;
        }

        else if(timer >= spawnInterval && !limited)
        {
            timer = 0.0f;
            GenerateQuestionAndOptions();
        }
    }

    void GenerateQuestionAndOptions() //a + b = answer
    {
        if (subtraction)
        {
            int randomForQuestion = Random.Range(1, 3);

            if (randomForQuestion <= 1)
            {
                AdditionGeneration();
            }

            if (randomForQuestion >= 2)
            {
                SubtractionGeneration();
            }
        }

        else
        {
            AdditionGeneration();
        }

        OpenQuestionPanel();      

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

    void AdditionGeneration()
    {
        answer = Random.Range(minNumber, maxNumber);
        a = Random.Range(minNumber, answer);
        b = answer - a;

        //wrongAnswer = Random.Range(answer + answerOffSet, answer - answerOffSet);
        WrongAnswerGeneration();
        questText.GetComponent<TextMeshProUGUI>().text = a + " + " + b + " = ? ";      //question generation

        //Debug.Log(a + " + " + b + " = " + answer + " wrong answer is " + wrongAnswer);
    }

    void SubtractionGeneration()
    {
        a = Random.Range(minNumber, maxNumber);
        answer = Random.Range(minNumber, a);
        b = a - answer;

        //wrongAnswer = Random.Range(answer + answerOffSet, answer - answerOffSet);
        WrongAnswerGeneration();
        questText.GetComponent<TextMeshProUGUI>().text = a + " - " + b + " = ? ";      //question generation      

        //Debug.Log(a + " - " + b + " = " + answer + " wrong answer is " + wrongAnswer);
    }

    void WrongAnswerGeneration()
    {
        wrongAnswer = Random.Range(answer + answerOffSet, answer - answerOffSet);

        if(wrongAnswer == answer)
        {
            WrongAnswerGeneration();
        }
    }

    void OpenQuestionPanel()
    {
        if (questionPanel != null)
        {
            Animator animator = questionPanel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("QuestionCome"); 

                animator.SetBool("QuestionCome", !isOpen); 
            }
        }
    }
}
