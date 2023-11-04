using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearEnemy : Enemy
{
    public float pushForce = 10f; 
    public float pushDistance = 2f;
    
    void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
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
