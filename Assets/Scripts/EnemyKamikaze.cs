using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyKamikaze : Enemy
{
    //public override int GetXp => 20;
    private void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}



