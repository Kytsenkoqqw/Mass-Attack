using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public int Death = 0;
   public static PlayerHealth instance;
   public event Action<float> OnChangeHP;
   public event Action OnDie;
   public float HP
   { 
      get =>_hp;
      set
      {
         _hp = value;
         if (_hp <= 0)
         {
            Die();
         }
         OnChangeHP?.Invoke(_hp);
      }
   }

   [SerializeField] private float _hp = 100f;

   private void Awake()
   {
      if(instance == null)
      {
         instance = this;
      }
   }
   
   

   private void Die()
   {
      OnDie?.Invoke();
      
      Destroy(gameObject);
   }
   
   
}
