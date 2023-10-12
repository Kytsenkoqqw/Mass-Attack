using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FireBall : MonoBehaviour, IDamageGiver
{
    public float Damage => DefaultDamage * _level + 10; 
    private bool _firsDie= false;
    [SerializeField]public float _level = 0;
    private const float DefaultDamage = 10;
    public static FireBall instance;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(FirstDieFireBall());
    }

    private void Update()
    {
        StartCoroutine(TimeDieFireBall());
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

    IEnumerator TimeDieFireBall()
    {
        if (_firsDie == true)
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject); 
        }
    }

    IEnumerator FirstDieFireBall()
    {
        yield return  new WaitForSeconds(4f);
        Destroy(gameObject);
        _firsDie = true;
    }

  
}
