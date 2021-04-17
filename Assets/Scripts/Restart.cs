using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Restart : MonoBehaviour
{
    public static Restart instance { get; private set; }
    public bool isPaused;

    void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        isPaused = false;
    }
    

    public void RestartGame()
    {

        SceneManager.LoadScene("Palloralli");
        Timer.instance.ClearTimer();
    }

    public void PauseGame()
    {
        if (isPaused == false) { 
        isPaused = true;
        Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
