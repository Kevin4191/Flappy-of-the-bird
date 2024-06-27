using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        //Set model to var
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas;


    private void Awake()
    {
        //check if null
        if (instance == null)
        {
            //if null set instance
            instance = this;
        }
        //define timescale
        Time.timeScale = 1f;
    }
    //game over func
    public void GameOver()
    {
        //set gameovercanvas to true
        _gameOverCanvas.SetActive(true);
        //set timescale
        Time.timeScale = 0f;
    }
    //func to restartgame
    public void RestartGame()
    {
        //load scene after restarted
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
