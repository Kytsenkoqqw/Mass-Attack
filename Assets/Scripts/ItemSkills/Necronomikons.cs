using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Necronomikons : Enemy
{
   public float DetectionRadius = 10f;
   protected override void Start()
   {
      base.Start();
      SearchForEnemies();
   }

   protected void OnCollisionEnter(Collision other)
   {
      
      
   }

   private void SearchForEnemies()
   {
      // Ищем все объекты с тегом "Enemy" в радиусе обнаружения
      Collider[] hitColliders = Physics.OverlapSphere(transform.position, DetectionRadius);

      // Обработка найденных врагов
      foreach (var collider in hitColliders)
      {
         if (collider.CompareTag("Enemy"))
         {
            Debug.Log("Found enemy: " + collider.gameObject.name);
         }
      }
   }
}
