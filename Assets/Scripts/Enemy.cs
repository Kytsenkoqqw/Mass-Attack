using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 1;
    public float damage = 15f;
    public Transform target; 
    public float moveSpeed = 15f;
    private Rigidbody rb;
    private Vector3 respawnPosition;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target != null)  
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.HP -= damage; 
        }
    }
}
