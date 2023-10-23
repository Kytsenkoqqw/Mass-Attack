using System.Collections;
using UnityEngine;

namespace Weapon
{
    public abstract class BulletWeapon<TBullet> : Weapon where TBullet : Bullet
    {
        protected virtual float DelayShoot { set; get; } = 1f;
        protected Transform _target;
        
        [SerializeField] protected float _bulletSpeed;
        [SerializeField] protected TBullet _bulletPrefab;
        
        [SerializeField] private float _detectionRadius = 10f;
        [SerializeField] private Transform _bulletSpawnPoint;
       
        
        
        private void Start()
        {
            StartCoroutine(ShootDelay());
        
        }

        private void Update()
        {
            SearchEnemy();
        }
        
        private void SearchEnemy ()
        {
            var colliders = Physics.OverlapSphere(transform.position, _detectionRadius);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    _target = collider.transform;
                    break;
                }
            }
        }
        
        protected virtual Rigidbody SpawnBullet()
        {
            var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            var rb = bullet.GetComponent<Rigidbody>();
            bullet.Damage = Damage;
            return rb;
        }

        protected virtual void ChoiceShootBullet()
        {
            SpawnBullet().velocity = (_target.position - _bulletSpawnPoint.position).normalized * _bulletSpeed;
        }

        protected virtual void LineShootBullet()
        {
            SpawnBullet().velocity = transform.forward * _bulletSpeed;
        }

        private IEnumerator ShootDelay()
        {
            while (true)
            {
                if (_target != null)
                {
                    ChoiceShootBullet();
                    yield return new WaitForSeconds(DelayShoot);
                }
                else if (_target == null)
                {
                    LineShootBullet();
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