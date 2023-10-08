using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    
    
    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        if (Time.timeScale !=1)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
