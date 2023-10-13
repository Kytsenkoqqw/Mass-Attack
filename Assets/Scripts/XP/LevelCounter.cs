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
        
        LevelUp(PlayerCharacter.instance.Level);
        PlayerCharacter.instance.LevelUp += LevelUp;
    }
    private void OnDestroy()
    {
        PlayerCharacter.instance.LevelUp -= LevelUp;
    }

    void Update()
    {
        
       
    }

    private void LevelUp( int level)
    {
        if (_lvlText.text != level.ToString())
        {
            _lvlText.text = level.ToString();
            Debug.Log(PlayerCharacter.instance.Level + " " + PlayerCharacter.instance.Experience);
        }
    }
    
}
