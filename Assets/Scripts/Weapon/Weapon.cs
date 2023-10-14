using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon<TBullet> : MonoBehaviour where TBullet : Bullet
{
    public int BulletLevel { set; get; } = 1;
    
    protected Transform Target;
    protected virtual float DelayShoot { set; get; } = 1f;
    
    [SerializeField] private float _detectionRadius = 10f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private TBullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _bulletSpeed;
    
    
    private bool _canShoot = true;
    
    private void Start()
    {
        StartCoroutine(ShootDelay());
    }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, _detectionRadius);
        foreach (var collider in colliders)
            if (collider.CompareTag("Enemy"))
            {
                Target = collider.transform;
                break;
            }
    }

    private Rigidbody SpawnBullet()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        bullet.Level = BulletLevel;
        return rb;
    }

    private void ShootBullet()
    {
        if (_canShoot) SpawnBullet().velocity = (Target.position - _bulletSpawnPoint.position).normalized * _bulletSpeed;
    }

    private void ChoiceShootBullet()
    {
        if (_canShoot) SpawnBullet().velocity = transform.forward * _bulletSpeed;
    }

    private IEnumerator ShootDelay()
    {
        while (true)
            if (_canShoot && Target != null)
            {
                ShootBullet();
                _canShoot = false;
                yield return new WaitForSeconds(DelayShoot);
                _canShoot = true;
            }
            else if (_canShoot && Target == null)
            {
                ChoiceShootBullet();
                _canShoot = false;
                yield return new WaitForSeconds(DelayShoot);
                _canShoot = true;
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
    }
}