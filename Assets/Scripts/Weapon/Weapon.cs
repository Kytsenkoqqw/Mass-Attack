using System.Collections;
using DefaultNamespace;
using UnityEngine;

public abstract class Weapon<TBullet> : MonoBehaviour where TBullet : Bullet
{
    public int BulletLevel { private set; get; } = 1;
    
    protected Transform Target;
    protected virtual float DelayShoot { set; get; } = 1f;
    
    [SerializeField] private float _detectionRadius = 10f;
    [SerializeField] private TBullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _bulletSpeed;

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
        BulletLevel++;
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
        bullet.Level = BulletLevel;
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