using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IHealth, IEnemyXP
{
    public int GetXp => _xp;
   [SerializeField] private  int _xp = 10;
   private float currentHealth = 100;
    private float maxHealth = 100;
    public int damage = 15;
    public Transform target;
    public float moveSpeed = 15f;
    private Rigidbody rb;
    private Vector3 respawnPosition;
    public float GetMaxHealth => maxHealth;

    public float Health
    {
        get
        {
            return currentHealth;
        }
        private set
        {
            currentHealth = Mathf.Clamp(value: value, 0f, maxHealth);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
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
