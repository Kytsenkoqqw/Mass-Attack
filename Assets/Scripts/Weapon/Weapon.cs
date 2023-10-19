using System.Collections;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon<TBullet> : MonoBehaviour, IWeapon where TBullet : Bullet
    {
        public abstract WeaponType Type { get; }
        public int BulletLevel { private set; get; } = 0;
        public virtual float Damage => DefaultDamage * BulletLevel + 10;
        public Sprite Icon => _icon;

        protected virtual  float DefaultDamage => 10;
        protected Transform Target;
        
        protected virtual float DelayShoot { set; get; } = 1f;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _detectionRadius = 10f;
        [SerializeField] private  Transform _bulletSpawnPoint;
        [SerializeField] private  float _bulletSpeed;
        [SerializeField] private TBullet _bulletPrefab;
   
        private void Start()
        {
            StartCoroutine(ShootDelay());
        
        }

        private void Update()
        {
            SearchEnemy();
        }

        public void BulletLevelUp()
        {
            if (!enabled)
            {
                enabled = true;
            }
            BulletLevel++;
        }

        public (int, float) GetPredicateStats()
        {
            BulletLevel++;
            (int, float) stats = (BulletLevel, Damage);
            BulletLevel--;
            return stats;
        }

        private void SearchEnemy ()
        {
            var colliders = Physics.OverlapSphere(transform.position, _detectionRadius);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Target = collider.transform;
                    break;
                }
            }
        }
    
        private Rigidbody SpawnBullet()
        {
            var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            var rb = bullet.GetComponent<Rigidbody>();
            bullet.Damage = Damage;
            return rb;
        }

        private void ShootBullet()
        {
            SpawnBullet().velocity = (Target.position - _bulletSpawnPoint.position).normalized * _bulletSpeed;
        }

        private void ChoiceShootBullet()
        {
            SpawnBullet().velocity = transform.forward * _bulletSpeed;
        }

        private IEnumerator ShootDelay()
        {
            while (true)
            {
                if (Target != null)
                {
                    ShootBullet();
                    yield return new WaitForSeconds(DelayShoot);
                }
                else if (Target == null)
                {
                    ChoiceShootBullet();
                    yield return new WaitForSeconds(DelayShoot);
                }
                else
                {
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
    }
}