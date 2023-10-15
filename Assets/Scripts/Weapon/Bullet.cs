using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Bullet : MonoBehaviour, IDamageGiver
    {
        public virtual float Damage => DefaultDamage * Level + 10;
        [HideInInspector] public float Level = 1;
        
        protected virtual  float DefaultDamage => 10;
        
        private void Start()
        {
            StartCoroutine(FirstDieBullet());
        }
        
        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
        
        IEnumerator FirstDieBullet()
        {
            yield return  new WaitForSeconds(4f);
            Destroy(gameObject);
        }
    }
}