using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Weapon;

public class Necronomikons : Enemy
{
   public float DetectionRadius = 30f;
   public override float GetMaxHealth => 999999999999999999999999999f;
   private EnemyKamikaze _enemy;
   protected override void Start()
   {
      _enemy = GameObject.FindObjectOfType<EnemyKamikaze>();
      base.Start();
   }

   protected override void FixedUpdate()
   {
      if (target == null)
      {
         _enemy = GameObject.FindObjectOfType<EnemyKamikaze>();
         target = _enemy.transform;
      }
      else
      {
         base.FixedUpdate();
      }
   }

   public override void OnCollisionEnter(Collision other)
   {
      
   }
}
