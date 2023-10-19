using UnityEngine;

namespace Weapon
{
    public interface IWeapon
    {
        public  WeaponType Type { get; }
        public int BulletLevel { get; }
        public float Damage { get; }
        public Sprite Icon { get; }

        public void BulletLevelUp();
        public (int, float) GetPredicateStats();
    }
}