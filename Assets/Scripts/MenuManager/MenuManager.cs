using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]private Button _playButton;

    private void Start()
    {
        _playButton.onClick.AddListener(Play);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
}
