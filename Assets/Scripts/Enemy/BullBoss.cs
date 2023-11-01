using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BullBoss : SpearEnemy
{
    public override float GetMaxHealth => 10000f;
    public PlayerController player;
    public float detectionRadius = 10f; // Радиус обнаружения игрока
    public float stopDuration = 3f; // Длительность остановки в секундах
    private Transform lastKnownPosition;
    
    private bool detectedPlayer = true;
    private float stopTime = 0f;
    
    protected override void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (!detectedPlayer)
        {
            BullRun();
            
            if (distanceToPlayer <= detectionRadius)
            {
                // Игрок обнаружен, останавливаем босса полностью и запускаем отсчет времени
                detectedPlayer = true;
                rb.velocity = Vector3.zero;
                stopTime = Time.time;
                Debug.Log("Игрок обнаружен");
            }
        }

        if (detectedPlayer && Time.time - stopTime >= stopDuration)
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
        float speed = 50f; // Скорость движения быка

        while (Vector3.Distance(transform.position, targetPosition) > 30f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        Debug.Log("Бык прибежал");
        yield return new WaitForSeconds(3f);
        detectedPlayer = false;
    }

    private void BullAttack()
    {
        
    }
}
