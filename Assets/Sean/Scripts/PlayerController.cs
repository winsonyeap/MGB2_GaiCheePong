using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))] //Joystick
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody; //Joystick
    [SerializeField] private FixedJoystick _joystick; //Joystick
    [SerializeField] private Animator _animator; //Joystick

    [SerializeField] private float _moveSpeed; //Joystick

    private void FixedUpdate()  //Joystick
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);  //Joystick
    }
    public float speed = 10000.0f;
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