using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Weapon;

public class Necronomikons : MoveMob, IDamageGiver
{
   public float Damage => 100;
   private Enemy _enemy;

   protected override void Start()
   {
      base.Start();
      StartCoroutine(DieNecronomikon());
   }

   protected override Transform GetTarget()
   {
      if (_enemy)
      {
         return _enemy.transform;
      }
      
      _enemy = GameObject.FindObjectOfType<Enemy>();
      return _enemy.transform;
   }
   
   private void OnCollisionEnter(Collision other)
   {
      IDamageable damageable = other.collider.GetComponent<IDamageable>();
      if (damageable != null)
      {
         damageable.TakeDamage(Damage);
      }
   }

   IEnumerator DieNecronomikon()
   {
      yield return new WaitForSeconds(5f);
      Destroy(gameObject);
   }


}
