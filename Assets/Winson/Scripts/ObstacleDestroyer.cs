using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Obstacle Parent"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle Parent"))
        {
            Destroy(other.gameObject);
            Debug.Log("destroy");
        }
    }
}
