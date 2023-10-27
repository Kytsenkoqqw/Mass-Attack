using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Weapon;
using Weapon.UI;

public class SpellPanelManager : MonoBehaviour
{
    [SerializeField] private WeaponIcon _prefab;
    [SerializeField] private Transform _parent;
    
    private void Start()
    {
        ReDraw();
        foreach (var weapon in WeaponManager.instance.Weapons)
        {
            weapon.OnLevelUp += OnLevelUp;
        }
    }

    private void OnLevelUp(int obj)
    {
        ReDraw();
    }

    private void OnDestroy()
    {
        foreach (var weapon in WeaponManager.instance.Weapons)
        {
            weapon.OnLevelUp -= OnLevelUp;
        }
    }

    private void ReDraw()
    {
        Clear();
        var weapons = WeaponManager.instance.ActiveWeapons;
        foreach (var weapon in weapons)
        {
            Instantiate(_prefab, _parent).Init(weapon.Icon);
        }
    }
    
    private void Clear()
    {
        foreach (Transform child in _parent)
        {
            Destroy(child.gameObject);
        }
    }
}
