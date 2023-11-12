using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public int Death = 0;
   public static PlayerHealth instance;
   public event Action<float> OnChangeHP;
   public event Action OnDie;
   private bool _isDead;
   [SerializeField] private float _hp = 100f;
   public float HP
   { 
      get =>_hp;
      set
      {
         _hp = value;
         if (_hp <= 0 && _isDead == false)
         {
            StartCoroutine(Die());
         }
         OnChangeHP?.Invoke(_hp);
      }
   }

   private void Awake()
   {
      if(instance == null)
      {
         instance = this;
      }
   }
 
   private IEnumerator Die()
   {
      _isDead = true;
      PlayerAnimations.instance.PlayDieAnimation();
      yield return new WaitForSeconds(1.5f);
      OnDie?.Invoke();
   }
}
