using System;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        
        public abstract WeaponType Type { get; }
        public event Action <int>OnLevelUp;
        public int Level { private set; get; } = 0;
        public virtual float Damage => DefaultDamage * Level + 10;
        public Sprite Icon => _icon;
        protected virtual float DefaultDamage => 10;
        [SerializeField] private Sprite _icon;
        
        public void LevelUp()
        {
            if (!enabled)
            {
                enabled = true;
            }
            Level++;
            OnLevelUp?.Invoke(Level);
        }

        public (int, float) GetPredicateStats()
        {
            Level++;
            (int, float) stats = (Level, Damage);
            Level--;
            return stats;
        }
    }
}