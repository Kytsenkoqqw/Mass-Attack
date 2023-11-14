using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        public static PlayerAnimations instance;
        private Animator _animator;
        private Coroutine _hitCoroutine;
        private Coroutine _chestCoroutine;
      
        
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }
        
        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void PlayMoveAnimation(float speed)
        {
            _animator.SetFloat("Speed", Mathf.Abs(speed));
        }

        public void PlayDieAnimation()
        {
            _animator.SetBool("Death", true);
        }

        public void GetHitAnimation()
        {
            if (_hitCoroutine != null)
            {
                StopCoroutine(_hitCoroutine);
            }
            
            _hitCoroutine = StartCoroutine(GetHit());
            _animator.SetBool("GetHit", true);
        }

        public void TakeChestAnimation(Action onCompleteAnimation)
        {
            if (_chestCoroutine != null)
            {
                StopCoroutine(_chestCoroutine);
            }

            _chestCoroutine = StartCoroutine(TakeChest(onCompleteAnimation));
            _animator.SetBool("TakeChest", true);
        }

        private IEnumerator GetHit()
        {
            yield return new WaitForSeconds(0.3f);
            _animator.SetBool("GetHit", false); 
        }

        private IEnumerator TakeChest(Action onCompleteAnimation)
        {
            yield return new WaitForSeconds(1.2f);
            onCompleteAnimation?.Invoke();
            _animator.SetBool("TakeChest", false);
        }
    }
    
}