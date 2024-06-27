using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
    {
        //set the defualt value
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    //set model to var
    [SerializeField] private GameObject _pipe;
    //create timer var
    private float _timer;

    private void Start()
    {
        //fire spawnpipe func
        SpawnPipe();
    }

    private void Update()
    {
        //check if timer is over maxtime
        if (_timer > _maxTime)
        {
            //if true spawn time and set timer to 0
            SpawnPipe();
            _timer = 0;
        }
        //increase timer with deltatime
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}