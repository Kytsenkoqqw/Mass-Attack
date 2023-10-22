using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
   public class SphereExortWeapon : Weapon
   {
      public override WeaponType Type => WeaponType.Exort;
      [SerializeField] private ExortSphere ExortPrefab;
      [SerializeField] private Transform SpawnPoint;
      private List<ExortSphere> _spheres = new List<ExortSphere>();
      protected override float DefaultDamage => 40;

      private void Start()
      {
         SpawnObject();
      }
      
      private void OnDestroy()
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
         var sphere = Instantiate(ExortPrefab, SpawnPoint.position, SpawnPoint.rotation);
         sphere.Player = SpawnPoint;
         //sphere.transform.parent = SpawnPoint;
         sphere.Damage = Damage;
         _spheres.Add(sphere);
      }
   }
}
