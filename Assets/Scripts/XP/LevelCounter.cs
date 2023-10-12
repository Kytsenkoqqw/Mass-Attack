using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelCounter : PlayerCharacter
{
    
    [SerializeField] private TextMeshProUGUI _lvlText;
    
    private void Start()
    {
        // Присвоение начального текста при старте
        UpdateLevelText(PlayerCharacter.instance.Level);
    }

    void Update()
    {
        if (_lvlText.text != Level.ToString())
        {
            UpdateLevelText(PlayerCharacter.instance.Level);
        }
    }

    // Метод для обновления текста уровня
    public void UpdateLevelText(int level)
    {
        _lvlText.text = level.ToString();
    }
        
    
    
}
