using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapon
{
   public class SphereExortWeapon : Weapon
   {
      public override WeaponType Type => WeaponType.Exort;
      [SerializeField] private ExortSphere ExortPrefab;
      [SerializeField] private Transform SpawnPoint;
      private List<ExortSphere> _spheres = new List<ExortSphere>();
      private int _checkLevel = 1;
     
      protected override float DefaultDamage => 40;

      private void Start()
      {
         SpawnObject();
         OnLevelUp += OnLvlUp;
      }
      
      private void OnDestroy()
      {
         OnLevelUp -= OnLvlUp;
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
         int _numSpheres = _spheres.Count;
         
         float angle = (360f / _numSpheres) * _numSpheres;
         float spawnAngle = angle * _numSpheres * Mathf.Deg2Rad; // Переводим угол в радианы
         float spawnX = Mathf.Cos(spawnAngle) * 2; // Расстояние от героя (в данном случае, 2 - вы можете изменить по желанию)
         float spawnZ = Mathf.Sin(spawnAngle) * 2;
         
         
         float heroY = SpawnPoint.position.y;
         Vector3 spawnPosition = new Vector3(SpawnPoint.position.x + spawnX, heroY, SpawnPoint.position.z + spawnZ);
         
         if (_numSpheres > 0)
         {
            Vector3 previousSpherePosition = _spheres[_numSpheres - 1].transform.position;
            float distanceBetweenSpheres = Vector3.Distance(spawnPosition, previousSpherePosition);
            spawnPosition = previousSpherePosition + (spawnPosition - previousSpherePosition).normalized * distanceBetweenSpheres;
         }
         var sphere = Instantiate(ExortPrefab, spawnPosition, Quaternion.identity);
         sphere.Player = SpawnPoint;
         sphere.Damage = Damage;
         _spheres.Add(sphere);
      }

      private void OnLvlUp(int level)
      {
         if (Level % 2 == 1)
         {
            SpawnObject();
         }
      }
   }
}
