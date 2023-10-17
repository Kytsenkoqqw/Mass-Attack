using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
    }

    public interface IHealth
    {
        float GetMaxHealth { get; }
        float Health { get; }
    }
}