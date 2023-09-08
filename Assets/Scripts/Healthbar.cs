using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    
    public Image hpBar;

    private void OnEnable()
    {
        PlayerHealth.instance.OnChangeHP += OnChangeHp;
    }

    private void OnDisable()
    {
        PlayerHealth.instance.OnChangeHP -= OnChangeHp;
    }
    
    private void OnChangeHp(float value)
    {
        var hp = Mathf.Clamp(value, 0, 100);
        hpBar.fillAmount = hp / 100;
       
    }
    
    

    

      
    
}
