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
        
        OnLevelUp(PlayerCharacter.instance.Level);
        PlayerCharacter.instance.OnLevelUp += OnLevelUp;
    }
    private void OnDestroy()
    {
        PlayerCharacter.instance.OnLevelUp -= OnLevelUp;
    }

    void Update()
    {
        
       
    }

    private void OnLevelUp( int level)
    {
        if (_lvlText.text != level.ToString())
        {
            _lvlText.text = level.ToString();
            Debug.Log(PlayerCharacter.instance.Level + " " + PlayerCharacter.instance.Experience);
        }
    }
    
}
