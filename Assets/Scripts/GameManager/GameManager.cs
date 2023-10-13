using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject LoseMenu;
    public GameObject OffJoystick;
    public GameObject OffHpCanvas;
    public GameObject LevelUpMenu;

    private void Start()
    {
        PlayerHealth.instance.OnDie+= OnDie;
        PlayerCharacter.instance.LevelUp += LevelUp;
    }
    
    private void OnDestroy()
    {
        PlayerHealth.instance.OnDie-= OnDie;
        PlayerCharacter.instance.LevelUp -= LevelUp;
    }

    private void OnDie()
    {   
        OffHpCanvas.SetActive(false);
        OffJoystick.SetActive(false);
        LoseMenu.SetActive(true);
        Time.timeScale = 0;
    }

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

    private void LevelUp(int level)
    {
        LevelUpMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void FireBallLevelUp()
    {
        FireBallShooter.instance.BulletLevel++;
        LevelUpMenu.SetActive(false);
        Time.timeScale = 1;    
    }
    
}
