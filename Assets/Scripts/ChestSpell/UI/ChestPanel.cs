using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;
using Weapon.UI;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] private WeaponCard _weaponCard;
    
    public void ReDraw(IWeapon weapon)
    {
        var predicateStats = weapon.GetPredicateStats();
        _weaponCard.Init(weapon.Type, predicateStats.Item2, predicateStats.Item1, weapon.Icon, OffChestPanel);
    }

    private void OffChestPanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
