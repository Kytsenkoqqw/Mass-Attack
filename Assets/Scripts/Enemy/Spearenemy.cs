using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearEnemy : Enemy
{
    public Transform spearTarget;
    public float pushForce = 10f; 
    public float pushDistance = 2f;

    void Update()
    {
        if (target != null)
        {
            MoveToTarget();
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

    void MoveToTarget()
    {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        Vector3 directionMove = (target.position - transform.position).normalized;
        rb.MovePosition(transform.position + directionMove * moveSpeed * Time.deltaTime);
    }
}
