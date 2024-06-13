using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone");
            Score.instance.UpdateScore();
        }
        else
        {
            Debug.Log("Something else entered the trigger zone: " + collision.gameObject.name);
        }
    }
}
