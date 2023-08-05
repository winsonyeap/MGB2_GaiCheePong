using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public DoubleChoiceQuestion doubleChoiceQuestion; // Reference to the DoubleChoiceQuestion script

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check for horizontal input
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0.0f, 0.0f);
        rb.velocity = moveDirection * speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftAnswer"))
        {
            doubleChoiceQuestion.HandleAnswerSelection(true);
        }
        else if (other.CompareTag("RightAnswer"))
        {
            doubleChoiceQuestion.HandleAnswerSelection(false);
        }
    }
}