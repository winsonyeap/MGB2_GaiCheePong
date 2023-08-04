using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Vector2 touchStartPos;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    float deltaX = touch.position.x - touchStartPos.x;
                    Vector3 moveDirection = new Vector3(deltaX, 0.0f, 0.0f);
                    rb.velocity = moveDirection * speed * Time.deltaTime;
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector3.zero;
                    break;
            }
        }
    }
}