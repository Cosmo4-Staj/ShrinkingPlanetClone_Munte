using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;
    public static bool isGameAlreadyOpen = false;

    public GameObject gameOverUI;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        isGameStarted = false;
        isGameEnded = false;
    }


    public void Restart()
    {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void OnLevelStarted()
    {
        isGameAlreadyOpen = true;
        isGameStarted = true;
    }

    public void OnLevelCompleted()
    {
    }

    public void OnLevelFailed()
    {
        isGameEnded = true;
        gameOverUI.SetActive(true);
    }
}
