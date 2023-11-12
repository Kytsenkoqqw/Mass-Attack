using UnityEngine;

namespace Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        public static PlayerAnimations instance;
        private Animator _animator;
        
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
    }
    
}