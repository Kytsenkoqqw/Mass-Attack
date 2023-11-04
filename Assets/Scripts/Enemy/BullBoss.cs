using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BullBoss : SpearEnemy
{
    public override float GetMaxHealth => 10000f;
    public float detectionRadius = 10f; // Радиус обнаружения игрока
    public float stopDuration = 3f; // Длительность остановки в секундах
    private Transform lastKnownPosition;
    
    private bool detectedPlayer = true;
    private float stopTime = 0f;
    
    protected override void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (!detectedPlayer || (detectedPlayer && distanceToPlayer >= detectionRadius))
        {
            BullRun();
            detectedPlayer = true;
        }
        else if (detectedPlayer && distanceToPlayer < detectionRadius)
        {
            StartCoroutine(Attack());
        }
    }

    private void BullRun()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            Vector3 directionMove = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + directionMove * moveSpeed * Time.deltaTime);
        }
    }
    
     private IEnumerator  Attack()
    {
        Vector3 targetPosition = target.position; // Последняя известная позиция игрока
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(3f);
        float speed = 50f;
        
        
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        
        detectedPlayer = false;
        yield break;
        Debug.Log("Бык прибежал");
    }
     
}
