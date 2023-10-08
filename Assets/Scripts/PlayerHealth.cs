using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public GameObject LoseMenu;
   public GameObject OffJoystick;
   public GameObject OffHpCanvas;
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
      OffHpCanvas.SetActive(false);
      OffJoystick.SetActive(false);
      Destroy(gameObject);
      LoseMenu.SetActive(true);
      Time.timeScale = 0;
   }
   
   
}
