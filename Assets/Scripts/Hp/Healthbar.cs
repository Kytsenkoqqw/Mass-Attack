using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public GameObject OffCanvas;
    public static Healthbar instance;
    public Image hpBar;
    private bool _getHit;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        PlayerHealth.instance.OnChangeHP += OnChangeHp;
    }
    
    private void OnDestroy()
    {
        PlayerHealth.instance.OnChangeHP -= OnChangeHp;
    }
    
    private void OnChangeHp(float value)
    {
        var hp = Mathf.Clamp(value, 0, 100);
        hpBar.fillAmount = hp / 100;
    }
}
