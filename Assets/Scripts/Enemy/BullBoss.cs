using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BullBoss : SpearEnemy
{
    public Animator animator;
    public override float GetMaxHealth => 10000f;
    [SerializeField] private float detectionRadius;   
    private Transform lastKnownPosition;
    private Coroutine _run;
    
    private bool detectedPlayer = true;
    private float stopTime = 0f;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (!detectedPlayer || (detectedPlayer && distanceToPlayer >= detectionRadius))
        {
            BullRun();
            detectedPlayer = true;
        }
        else if (detectedPlayer && distanceToPlayer < detectionRadius && _run == null)
        {
           _run = StartCoroutine(Attack());
        }
    }

    private void BullRun()
    {
        if (target != null && _run == null)
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
        animator.SetBool("IsRun", false );
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("IsRun", true );
        float speed = 50f;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        
        detectedPlayer = false;
        _run = null;
        Debug.Log("Бык прибежал");
    }
     
}


