using System;
using System.Collections.Generic;
using Extention;
using UnityEngine;

namespace Weapon.UI
{
    public class WeaponCardManager : MonoBehaviour

    {
        [SerializeField] private WeaponCard _prefab;
        [SerializeField] private Transform _parent;

        private void Start()
        {
            ReDraw();
        }

        private void ReDraw()
        {
            Clear();

            List<IWeapon> availableWeapons = new List<IWeapon>(WeaponManager.instance.Weapons);
            availableWeapons.Shuffle();
            
            for (int i = 0; i < 3 && availableWeapons.Count > 0; i++)
            {
                IWeapon weapon = availableWeapons[i];
                var predicateStats = weapon.GetPredicateStats();
                Instantiate(_prefab, _parent).Init(weapon.Type, predicateStats.Item2, predicateStats.Item1, weapon.Icon,
                    () => LevelUpWeapon(weapon));
            }
        }

        private void Clear()
        {
            foreach (Transform child in _parent)
            {
                Destroy(child.gameObject);
            }
        }

        private void LevelUpWeapon(IWeapon weapon)
        {
            weapon.LevelUp();
            GameManager.instance.DisableLevelUpMenu();
            ReDraw();
        }
    }
}