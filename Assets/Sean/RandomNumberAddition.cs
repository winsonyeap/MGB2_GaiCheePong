using UnityEngine;
using UnityEngine.UI;

public class RandomNumberAddition : MonoBehaviour
{
   
    public Text equationText;
    public Text instructionText;
    public Text leftAnswerText;
    public Text rightAnswerText;

    private int randomNumber1;
    private int randomNumber2;
    private int correctAnswer;
    private int playerAnswer = -1; // -1 means no answer selected

    private void Start()
    {
        GenerateRandomNumbers();
        CalculateResult();
        DisplayEquation();
    }

    private void GenerateRandomNumbers()
    {
        randomNumber1 = Random.Range(0, 10);
        randomNumber2 = Random.Range(0, 10);
    }

    private void CalculateResult()
    {
        correctAnswer = randomNumber1 + randomNumber2;
    }

    private void DisplayEquation()
    {
        equationText.text = $"({randomNumber1} + {randomNumber2}) = ?";
        leftAnswerText.text = correctAnswer.ToString();
        rightAnswerText.text = (correctAnswer + 1).ToString();
    }

    private void Update()
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

    private void SelectAnswer(int choice)
    {
        if (playerAnswer == -1) // Only allow selecting an answer once
        {
            playerAnswer = choice;

            if (playerAnswer == 0)
            {
                HandleAnswerSelection(true);
            }
            else if (playerAnswer == 1)
            {
                HandleAnswerSelection(false);
            }
        }
    }

    private void HandleAnswerSelection(bool isLeftAnswer)
    {
        if (isLeftAnswer && correctAnswer == randomNumber1 + randomNumber2)
        {
            instructionText.text = "Correct!";
            leftAnswerText.color = Color.green;
        }
        else if (!isLeftAnswer && correctAnswer == randomNumber1 + randomNumber2 + 1)
        {
            instructionText.text = "Correct!";
            rightAnswerText.color = Color.green;
        }
        else
        {
            instructionText.text = "Incorrect. Try again!";
            if (isLeftAnswer)
            {
                leftAnswerText.color = Color.red;
            }
            else
            {
                rightAnswerText.color = Color.red;
            }
        }
    }
}