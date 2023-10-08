using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public GameObject OffJoystick;
   public GameObject OffCanvas;
   public int Death = 0;
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

   private void Update()
   {
      if (_hp <= 0)
      {
         Die();
      }
   }

   public void Die()
   {
      OffCanvas.SetActive(false);
      OffJoystick.SetActive(false);
      Destroy(gameObject);
      Time.timeScale = 0;
   }
   
   
}
