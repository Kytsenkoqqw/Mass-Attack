using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Weapon
{
   public class SphereExortWeapon : Weapon
   {
      public override WeaponType Type => WeaponType.Exort;
      [SerializeField] private ExortSphere ExortPrefab;
      [SerializeField] private Transform SpawnPoint;
      private List<ExortSphere> _spheres = new List<ExortSphere>();
      private int _sphereAmount = 0;

      protected override float DefaultDamage => 40;
      
      private void OnDestroy()
      {
         DestroySpheres();
      }

      private void DestroySpheres()
      {
         foreach (var sphere in _spheres)
         {
            if (sphere)
            {
               Destroy(sphere.gameObject);
            }
         }
      }

      private void SpawnObject()
      {
         DestroySpheres();
         for (int i = 0; i < _sphereAmount; i++)
          {
             int numSpheres = _sphereAmount;
             float totalAngle = 360f;

             // Вычисляем угол для равномерного распределения сфер вокруг героя
             float angle = totalAngle * (((float)_spheres.Count + 1) / numSpheres);
             float spawnAngle = angle * Mathf.Deg2Rad;
             float radius = 8f; // Расстояние от героя до сферы

             // Вычисляем положение сферы в полярных координатах
             float spawnX = Mathf.Cos(spawnAngle) * radius;
             float spawnZ = Mathf.Sin(spawnAngle) * radius;

             Vector3 spawnPosition = SpawnPoint.position + new Vector3(spawnX, 0, spawnZ);

             var sphere = Instantiate(ExortPrefab, spawnPosition, Quaternion.identity);
             sphere.Player = SpawnPoint;
             sphere.Damage = Damage;
             sphere.BaseAngle = spawnAngle; 
             sphere.Radius = radius; 
             _spheres.Add(sphere);
          }
      }
      
      protected override void LevelUpInternal()
      {
         Debug.Log(Level % 2);
         if (Level % 2 != 0)
         {
            _sphereAmount++;
            SpawnObject();
         }
      }
   }
}
