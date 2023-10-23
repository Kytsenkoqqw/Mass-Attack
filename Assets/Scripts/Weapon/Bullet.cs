using System.Collections;
using UnityEngine;

namespace Weapon
{
    public abstract class Bullet : MonoBehaviour, IDamageGiver
    {
        public virtual float Damage { get; set; }
        
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
                DestroyThis();
            }
        }

        IEnumerator FirstDieBullet()
        {
            yield return  new WaitForSeconds(4f);
            Destroy(gameObject);
        }

        protected virtual void DestroyThis()
        {
            Destroy(gameObject);
        }
    }
}