using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleDestroyer : MonoBehaviour
{
    public GameObject questText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle Parent"))
        {
            Destroy(other.gameObject);
            //questText.GetComponent<TextMeshProUGUI>().text = "";
            //Debug.Log("destroy");
        }
    }
}
