using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //Set var with score class
    public static Score instance;
    //Set default value for vars

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    //define score var
    private int _score;

    private void Awake()
    {   
        //check if instance null
        if (instance == null)
        {
            //if null create
            instance = this;
        }
    }

    private void Start()
    {
        //set scoretext to score
        _currentScoreText.text = _score.ToString();
        //set highscore text
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //fire func
        UpdateHighScore();
    }

    private void UpdateHighScore()
    
    {
        //check if current score higher than the highscore
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {   
            //set the new highscore
            PlayerPrefs.SetInt("HighScore", _score);
            //set the highscore text to new highscore
            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        //update the score
        _score++;
        //set the score text to score
        _currentScoreText.text = _score.ToString();
        //fire updatehighscore func
        UpdateHighScore();
    }
}
