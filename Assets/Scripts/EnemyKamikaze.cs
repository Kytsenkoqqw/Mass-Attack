using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikaze : Enemy
{
    private void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

/*&private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("FireBall"))
    {
        Destroy(gameObject);
    }
*/

