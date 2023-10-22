﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Weapon
{
    public class WeaponManager: MonoBehaviour, IWeaponManager
    {
        public IReadOnlyList<IWeapon> Weapons => new List<IWeapon>(){_fireballBulletWeapon,_manaSphereBulletWeapon,_poisonSphereBulletWeapon, _sphereExortWeapon};
        public static IWeaponManager instance;
        [SerializeField] private BulletWeapon<FireBall> _fireballBulletWeapon;
        [SerializeField] private BulletWeapon<ManaSphere> _manaSphereBulletWeapon ;
        [SerializeField] private BulletWeapon<PoisonSphere> _poisonSphereBulletWeapon ;
        [SerializeField] private Weapon _sphereExortWeapon;
        

        public IWeapon GetWeapon (WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Fire:
                    return _fireballBulletWeapon;
                case WeaponType.Mana:
                    return _manaSphereBulletWeapon;
                case WeaponType.Poison:
                    return _poisonSphereBulletWeapon;
                case WeaponType.Exort:
                    return _sphereExortWeapon;
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