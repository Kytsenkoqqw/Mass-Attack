using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public int maxHealth = 100;
    private int currentHealth;
    public int damage = 15;
    public Transform target; 
    public float moveSpeed = 15f;
    private Rigidbody rb;
    private Vector3 respawnPosition;
    
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
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
    
     public virtual void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.HP -= damage; 
        }
    }
}
