using System.Collections;
using UnityEngine;

namespace Weapon
{
    public abstract class BulletWeapon<TBullet> : Weapon where TBullet : Bullet
    {
        protected virtual float DelayShoot { set; get; } = 1f;
        
        [SerializeField] private float _detectionRadius = 10f;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private TBullet _bulletPrefab;
        
        private Transform _target;
   
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
    
        private Rigidbody SpawnBullet()
        {
            var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            var rb = bullet.GetComponent<Rigidbody>();
            bullet.Damage = Damage;
            return rb;
        }

        private void ShootBullet()
        {
            SpawnBullet().velocity = (_target.position - _bulletSpawnPoint.position).normalized * _bulletSpeed;
        }

        private void ChoiceShootBullet()
        {
            SpawnBullet().velocity = transform.forward * _bulletSpeed;
        }

        private IEnumerator ShootDelay()
        {
            while (true)
            {
                if (_target != null)
                {
                    ShootBullet();
                    yield return new WaitForSeconds(DelayShoot);
                }
                else if (_target == null)
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