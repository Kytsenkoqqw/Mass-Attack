using System.Collections;
using UnityEngine;

namespace DefaultNamespace
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