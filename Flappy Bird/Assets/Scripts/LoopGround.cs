using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    //Set vars to standard value
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _width = 6f;

    //Set models to vars
    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize;
    //Start func
    private void Start()
    {
        //Get comp from game and put it to var
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //Set var to vector with params
        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    private void Update()
    {
        //update the spriderenderer
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + _speed * Time.deltaTime, _spriteRenderer.size.y);
        //check if x is bigger than width
        if (_spriteRenderer.size.x > _width)
        {
            //if true set to startsize
            _spriteRenderer.size = _startSize;
        }
    }
}
