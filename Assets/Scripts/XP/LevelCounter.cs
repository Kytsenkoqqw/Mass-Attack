using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelCounter : PlayerCharacter
{
    
    [SerializeField] private TextMeshProUGUI _lvlText;
    private int _level = PlayerCharacter.instance.Level;
    
    private void Start()
    {
        // Присвоение начального текста при старте
        UpdateLevelText(_level);
    }

    void Update()
    {
        _level = PlayerCharacter.instance.Level;
        if (_lvlText.text != _level.ToString())
        {
            UpdateLevelText(_level);
        }
    }

    // Метод для обновления текста уровня
    public void UpdateLevelText(int _level)
    {
        _lvlText.text = _level.ToString();
        Debug.Log(PlayerCharacter.instance.Level + " " + PlayerCharacter.instance.Experience);
    }
        
    
    
}
