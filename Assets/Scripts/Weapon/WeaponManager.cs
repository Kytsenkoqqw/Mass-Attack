using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Weapon
{
    public class WeaponManager: MonoBehaviour, IWeaponManager
    {
        public IReadOnlyList<IWeapon> Weapons => new List<IWeapon>(){_fireballWeapon,_manaSphereWeapon,_poisonSphereWeapon};
        public static IWeaponManager instance;
        [SerializeField] private Weapon<FireBall> _fireballWeapon;
        [SerializeField] private Weapon<ManaSphere> _manaSphereWeapon ;
        [SerializeField] private Weapon<PoisonSphere> _poisonSphereWeapon ;
        

        public IWeapon GetWeapon (WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Fire:
                    return _fireballWeapon;
                case WeaponType.Mana:
                    return _manaSphereWeapon;
                case WeaponType.Poison:
                    return _poisonSphereWeapon;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            return null;
            //_weapons.FirstOrDefault(weapon => weapon.Type == type);
        }

        private void Awake()
        {
            instance = this;
        }
    }
}