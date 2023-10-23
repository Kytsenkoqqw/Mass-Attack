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
        public float radius = 10.0f; // Радиус падения молнии
        public float height = 50.0f; // Высота, на которой молния появляется
        public Thunderbolt ThunderboltPrefab; // Префаб объекта молнии
        public Transform HeroTransform; // Трансформ героя


        

        protected override void ShootBullet()
        {
            base.ShootBullet();
        }

        protected override void ChoiceShootBullet()
        {
            base.ChoiceShootBullet();
        }

        protected override Rigidbody SpawnBullet()
        {
            // Создайте экземпляр молнии
            Thunderbolt thunderbolt = Instantiate(ThunderboltPrefab, _target.position,quaternion.identity);

            // Вызовите метод для настройки позиции молнии
            thunderbolt.SpawnAtPosition(HeroTransform.position);
        }
    }
}


