using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public static PlayerHealth instance;
   public event Action<float> OnChangeHP;
   public float HP
   { 
      get =>_hp;
      set
      {
         _hp = value;
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
}
