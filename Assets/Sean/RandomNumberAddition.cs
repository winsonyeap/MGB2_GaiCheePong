using UnityEngine;
using UnityEngine.UI;

public class RandomNumberAddition : MonoBehaviour
{
    public Text equationText;
    public Text instructionText;
    public Text leftAnswerText;
    public Text rightAnswerText;

    private int totalQuestions = 10;
    private int currentQuestion = 0;
    private int correctAnswer;
    private int randomNumber1;
    private int randomNumber2;
    private bool isGameActive = true;
    private bool isQuestionActive = false;
    private float answerTime = 10f; // Time in seconds to answer each question
    private float restTime = 5f;   // Time in seconds between questions

    private void Start()
    {
        NextQuestion();
    }

    private void NextQuestion()
    {
        if (currentQuestion < totalQuestions)
        {
            isQuestionActive = true; // Allow answering the question
            GenerateRandomNumbers();
            CalculateResult();
            DisplayEquation();

            instructionText.text = "Tilt left or right to select your answer!";
            leftAnswerText.color = Color.black;
            rightAnswerText.color = Color.black;

            Invoke("EndQuestion", answerTime); // Automatically end the question after answerTime seconds

            currentQuestion++;
        }
        else
        {
            EndGame();
        }
    }

    private void EndQuestion()
    {
        isQuestionActive = false;
        instructionText.text = "Time's up! Try the next question.";
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

    private void CalculateResult()
    {
        // Nothing to calculate since the correct answer is set during random number generation
    }

    private void DisplayEquation()
    {
        equationText.text = $"({randomNumber1} + {randomNumber2}) = ?";
        leftAnswerText.text = correctAnswer.ToString();
        rightAnswerText.text = (correctAnswer + 1).ToString();
    }

    private void Update()
    {
        if (isGameActive && isQuestionActive)
        {
            float tilt = Input.acceleration.x;

            if (tilt < -0.5f)
            {
                SelectAnswer(0); // Tilted to the left
            }
            else if (tilt > 0.5f)
            {
                SelectAnswer(1); // Tilted to the right
            }
        }
    }

    private void SelectAnswer(int choice)
    {
        if (correctAnswer == randomNumber1 + randomNumber2 && choice == 0)
        {
            HandleAnswerSelection(true);
        }
        else if (correctAnswer == randomNumber1 + randomNumber2 + 1 && choice == 1)
        {
            HandleAnswerSelection(false);
        }
        else
        {
            HandleIncorrectSelection();
        }
    }

    private void HandleAnswerSelection(bool isLeftAnswer)
    {
        isQuestionActive = false;
        instructionText.text = "Correct!";
        if (isLeftAnswer)
        {
            leftAnswerText.color = Color.green;
        }
        else
        {
            rightAnswerText.color = Color.green;
        }
        Invoke("NextQuestion", restTime); // Move to the next question after restTime seconds
    }

    private void HandleIncorrectSelection()
    {
        isQuestionActive = false;
        instructionText.text = "Incorrect. Try again!";
    }

    private void EndGame()
    {
        instructionText.text = "Game Over";
        isGameActive = false;
    }
}