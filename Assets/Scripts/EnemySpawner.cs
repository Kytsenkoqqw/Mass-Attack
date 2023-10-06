using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 4f;
    private float timeSinceLastSpawn = 0f;
    private PlayerController player;
    public Transform[] spawnPoints;
    public Enemy[] enemyPrefabs;
    
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
        Transform randomSpawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

        // Выбираем случайный префаб врага из массива.
        Enemy randomEnemyPrefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];

        // Создаем врага в выбранной точке спавна.
        var newEnemy = Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        if (player != null)
        {
            newEnemy.transform.LookAt(player.transform);
            newEnemy.target = player.transform;
        }
    }
}
