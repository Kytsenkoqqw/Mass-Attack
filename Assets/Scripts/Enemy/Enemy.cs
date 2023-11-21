using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Weapon;

public class Enemy : MonoBehaviour, IDamageable, IHealth, IEnemyXP
{
    public virtual int GetXp => _xp;
    [SerializeField] private  int _xp = 10;
    private float currentHealth = 100;
    private PlayerController player;
    private float maxHealth = 100;
    public int damage = 15;
    public Transform target;
    public float moveSpeed = 15f;
    public Rigidbody rb;
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

    protected virtual void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();
        currentHealth = GetMaxHealth;
    }
    
    protected virtual void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            Vector3 directionMove = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + directionMove * moveSpeed * Time.deltaTime);
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
