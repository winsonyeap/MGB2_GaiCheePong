using UnityEngine;
using UnityEngine.UI;

public class DoubleChoiceQuestion : MonoBehaviour
{
    public Text equationText;
    public Text instructionText;
    public Text leftAnswerText;
    public Text rightAnswerText;
    public GameObject rocket;

    private int totalQuestions = 10;
    private int currentQuestion = 0;
    private int correctAnswer;
    private int randomNumber1;
    private int randomNumber2;

    private bool isQuestionActive = false;

    private float answerTime = 10f; // Time in seconds to answer each question
    private float restTime = 5f;   // Time in seconds between questions

    private void Start()
    {
        NextQuestion();
    }

    private void Update()
    {
        if (isQuestionActive)
        {
            leftAnswerText.color = Color.black;
            rightAnswerText.color = Color.black;
        }
    }

    private void NextQuestion()
    {

        if (currentQuestion < totalQuestions)
        {
            currentQuestion++;
            GenerateRandomNumbers();
            DisplayEquation();

            isQuestionActive = true; // Allow answering the question
            CancelInvoke("NextQuestion");
            Invoke("EndQuestion", answerTime); // Automatically end the question after answerTime seconds
            
        }
        else
        {
            EndGame();
        }

        rocket.transform.position = new Vector3(0f, -10f, 68.2f);

    }
    private void ShowNextQuestion()
    {
        instructionText.text = ""; // Clear instruction text
        NextQuestion();
    }
    private void EndQuestion()
    {
        isQuestionActive = false;
        //instructionText.text = "Time's up! Try the next question.";
        leftAnswerText.color = Color.black;
        rightAnswerText.color = Color.black;
        Invoke("NextQuestion", restTime); // Move to the next question after restTime seconds
    }

    private void GenerateRandomNumbers()
    {
        int maxNumber = 9; // Adjust this if you want a different range
        correctAnswer = Random.Range(0, maxNumber + 1);
        int offset = Random.Range(1, maxNumber + 1);
        randomNumber1 = correctAnswer - offset;
        randomNumber2 = offset;
    }

    private void DisplayEquation()
    {
        equationText.text = $"({randomNumber1} + {randomNumber2}) = ?";
        bool isLeftCorrect = Random.Range(0, 2) == 0;

        if (isLeftCorrect)
        {
            leftAnswerText.text = correctAnswer.ToString();
            rightAnswerText.text = (correctAnswer + 1).ToString();
        }
        else
        {
            leftAnswerText.text = (correctAnswer + 1).ToString();
            rightAnswerText.text = correctAnswer.ToString();
        }
    }

    public void HandleAnswerSelection(bool isLeftAnswer)
    {
        if (isQuestionActive)
        {
            int selectedAnswer = isLeftAnswer ? int.Parse(leftAnswerText.text) : int.Parse(rightAnswerText.text);

            if (selectedAnswer == correctAnswer)
            {
                instructionText.text = "Correct!";
                if (isLeftAnswer)
                {
                    leftAnswerText.color = Color.green;
                }
                else
                {
                    rightAnswerText.color = Color.green;
                }
            }
            else
            {
                instructionText.text = "Incorrect!";
            }

            isQuestionActive = false; // Prevent answering while showing feedback

            Invoke("ShowNextQuestion", 3f); // Show the next question after 3 seconds
        }
    }

    private void EndGame()
    {
        instructionText.gameObject.transform.position = new Vector3(0f, 0f, 68.2f);
        instructionText.gameObject.transform.localScale = new Vector3(2,2,2);
        instructionText.text = "Game Over";

        equationText.gameObject.SetActive(false);
        leftAnswerText.gameObject.SetActive(false);
        rightAnswerText.gameObject.SetActive(false);

        rocket.SetActive(false);
    }
}
