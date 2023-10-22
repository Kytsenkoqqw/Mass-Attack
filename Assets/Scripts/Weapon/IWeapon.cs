﻿using UnityEngine;

namespace Weapon
{
    public interface IWeapon
    {
        public  WeaponType Type { get; }
        public int Level { get; }
        public float Damage { get; }
        public Sprite Icon { get; }

        public void LevelUp();
        public (int, float) GetPredicateStats();
    }
}