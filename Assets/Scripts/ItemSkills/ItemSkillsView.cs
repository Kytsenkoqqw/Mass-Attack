using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSkillsView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    
    public void Init(  Sprite icon, Action onClick )
    {
        _icon.sprite = icon;
        _button.onClick.AddListener(()=>onClick?.Invoke());
    }
}
