using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [FormerlySerializedAs("PauseMenu")] [SerializeField] private GameObject _pauseMenu;
    [FormerlySerializedAs("LoseMenu")] [SerializeField] private  GameObject _loseMenu;
    [FormerlySerializedAs("OffJoystick")] [SerializeField] private  GameObject _joystick;
    [FormerlySerializedAs("OffHpCanvas")] [SerializeField] private  GameObject _hpCanvas;
    [FormerlySerializedAs("LevelUpMenu")] [SerializeField] private  GameObject _levelUpMenu;
    [SerializeField] private GameObject _player;

    private void Start()
    {
        PlayerHealth.instance.OnDie+= OnDie;
        PlayerCharacter.instance.LevelUp += LevelUp;
        _levelUpMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void OnDestroy()
    {
        PlayerHealth.instance.OnDie-= OnDie;
        PlayerCharacter.instance.LevelUp -= LevelUp;
    }

    private void OnDie()
    {   
        _hpCanvas.SetActive(false);
        _joystick.SetActive(false);
        _loseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        if (Time.timeScale !=1)
        {
            _pauseMenu.SetActive(false);
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
        _levelUpMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void FireBallLevelUp()
    {
        FireBallWeapon.instance.BulletLevelUp();
        _levelUpMenu.SetActive(false);
        Time.timeScale = 1;    
    }
    
    public void ManaSphereLevelUp()
    {
        ManaSphereWeapon.instance.BulletLevelUp();
        _levelUpMenu.SetActive(false);
        Time.timeScale = 1;    
    }
    
    public void PoisonSphereLevelUP()
    {
        PoisonSphereWeapon.instance.BulletLevelUp();
        _levelUpMenu.SetActive(false);
        Time.timeScale = 1;    
    }
    
    
}
