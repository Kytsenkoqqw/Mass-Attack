using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Bullet : MonoBehaviour, IDamageGiver
    {
        public float Damage => DefaultDamage * Level + 10; 
        private bool _firsDie= false;
        [HideInInspector]public float Level = 1;
        private const float DefaultDamage = 10;
    
    
   
        private void Start()
        {
            StartCoroutine(FirstDieBullet());
        }

        private void Update()
        {
            StartCoroutine(TimeDieBullet());
        }
    
        private void OnTriggerEnter(Collider other)
        {
        
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(Damage); // Пример: игрок наносит 10 единиц урона
                float currentHealth = (damageable as IHealth).Health;
                float maxHealth = (damageable as IHealth).GetMaxHealth;
                Debug.Log("Здоровье врага: " + currentHealth + " / " + maxHealth);
                Destroy(gameObject);
            }
        
        }

        IEnumerator TimeDieBullet()
        {
            if (_firsDie == true)
            {
                yield return new WaitForSeconds(1f);
                Destroy(gameObject); 
            }
        }

        IEnumerator FirstDieBullet()
        {
            yield return  new WaitForSeconds(4f);
            Destroy(gameObject);
            _firsDie = true;
        }
    }
}