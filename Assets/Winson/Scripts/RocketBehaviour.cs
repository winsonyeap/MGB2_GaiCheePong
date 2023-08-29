using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [Tooltip("How fast the ball moves left/right")]
    public float dodgeSpeed = 5;

    [Tooltip("How fast the ball moves forwards automatically")]
    [Range(0, 10)]
    public float rollSpeed = 5;

    public enum MobileHorizMovement
    {
        Accelerometer, ScreenTouch
    }

    public MobileHorizMovement horizMovement = MobileHorizMovement.Accelerometer;

    void Start()
    {
        // Get access to our Rigidbody component
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        // Check if we are running on a mobile device
#if UNITY_IOS || UNITY_ANDROID

        if (horizMovement == MobileHorizMovement.Accelerometer)
        {
            // Move player based on direction of the accelerometer
            horizontalSpeed = Input.acceleration.x * dodgeSpeed;
        }

#endif
    }

    private void FixedUpdate()
    {
        // Check if we're moving to the side
        float horizontalSpeed = 0;

        // Check if we are running either in the Unity editor or in a    
        // standalone build.
    #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        // Check if we're moving to the side
        horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        // If the mouse is held down (or the screen is pressed on Mobile)
        if (Input.GetMouseButton(0))
        {
            horizontalSpeed = CalculateMovement(Input.mousePosition);
        }

        // Check if we are running on a mobile device
#elif UNITY_IOS || UNITY_ANDROID
            // Check if Input has registered more than zero touches        
            if (Input.touchCount > 0)        
            {            
                // Store the first touch detected.            
                Touch touch = Input.touches[0];            
                horizontalSpeed = CalculateMovement(touch.position);        
            }    
#endif

        rb.AddForce(horizontalSpeed, 0, rollSpeed);
    }

    private float CalculateMovement(Vector3 pixelPos)
    {
        // Converts to a 0 to 1 scale
        var worldPos = Camera.main.ScreenToViewportPoint(pixelPos);
        float xMove = 0;

        // If we press the right side of the screen
        if (worldPos.x < 0.5f)
        {
            xMove = -1;
        }

        else 
        {
            // Otherwise we're on the left
            xMove = 1;
        }

        // replace horizontalSpeed with our own value
        return xMove * dodgeSpeed;
    }
}
