using System;
using UnityEngine;

namespace Weapon.UI
{
    public class WeaponCardManager: MonoBehaviour

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
            foreach (var weapon in WeaponManager.instance.Weapons)
            {
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