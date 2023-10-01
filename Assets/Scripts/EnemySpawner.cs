using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float spawnInterval = 4f;
    private float timeSinceLastSpawn = 0f;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        if (player != null)
        {
            newEnemy.transform.LookAt(player.transform);
            newEnemy.target = player.transform;
        }
    }
}
