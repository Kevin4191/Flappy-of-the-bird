using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    //Set default value speed
    [SerializeField] private float _speed = 0.65f;

    private void Update()
    {   
        //Set the pipe
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
