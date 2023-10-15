using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearenemy : Enemy
{
    public Transform spearTarget;
    public float pushForce = 10f; 
    public float pushDistance = 2f;

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            Vector3 directionMove = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + directionMove * moveSpeed * Time.deltaTime);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }
}
