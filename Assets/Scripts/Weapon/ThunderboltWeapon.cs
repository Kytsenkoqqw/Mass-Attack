using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Weapon;
using Random = UnityEngine.Random;

namespace Weapon
{
    public class ThunderboltWeapon : BulletWeapon<Thunderbolt>
    {
        public override WeaponType Type => WeaponType.Thunderbolt;
        [SerializeField] private float _offsetY;

        protected override float DefaultDamage => 40;
        protected override float DelayShoot => 3;

        

        protected override void ChoiceShootBullet()
        {
           SpawnBullet().AddForce(Vector3.down * _bulletSpeed, ForceMode.Impulse);
        }

        protected override void LineShootBullet()
        {
          
        }

        protected override Rigidbody SpawnBullet()
        {
            var position = new Vector3(_target.position.x, _target.position.y + _offsetY, _target.position.z);
            Thunderbolt thunderbolt = Instantiate(_bulletPrefab, position ,quaternion.identity);
            var rb = thunderbolt.GetComponent<Rigidbody>();
            thunderbolt.Damage = Damage;
            return rb;
        }
    }
}


