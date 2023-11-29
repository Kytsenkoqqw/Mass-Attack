using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Weapon;

public class Enemy : MoveMob, IDamageable, IHealth, IEnemyXP
{
    public static event System.Action<GameObject> OnEnemyDeath;
    public virtual int GetXp => _xp;
    [SerializeField] private  int _xp = 10;
    private float currentHealth = 100;
    
    private float maxHealth = 100;
    public int damage = 15;
    public Transform target;
    private Vector3 respawnPosition;
    public virtual float GetMaxHealth => maxHealth;

    public float Health
    {
        get
        {
            return currentHealth;
        }
        private set
        {
            currentHealth = Mathf.Clamp(value: value, 0f, GetMaxHealth);
        }
    }
    
    private void OnDestroy()
    {
        // Генерируем событие при смерти врага
        OnEnemyDeath?.Invoke(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        currentHealth = GetMaxHealth;
    }

    protected override Transform GetTarget()
    {
        return target;
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.HP -= damage;
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(Health + "-" + damage);
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        if (player != null)
        {
            player.AddExperience(_xp);
        }
        Destroy(gameObject);
    }

    
}
