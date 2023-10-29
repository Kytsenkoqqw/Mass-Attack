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
    [SerializeField ]private Enemy _bullBossPrefab;
    
    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        PlayerCharacter.instance.OnLevelUp += OnLevelUp;
    }

    private void OnDestroy()
    {
        PlayerCharacter.instance.OnLevelUp -= OnLevelUp;
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
        Spawn(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)]);
    }

    private void SpawnBullBoss()
    {
        Spawn(_bullBossPrefab);
    }

    private void Spawn(Enemy enemyPrefab)
    {
        Transform randomSpawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        var newEnemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        if (player != null)
        {
            newEnemy.transform.LookAt(player.transform);
            newEnemy.target = player.transform;
        }
    }

    private void OnLevelUp(int level)
    {
        if (level == 3)
        {
            SpawnBullBoss();
        }
    }
}
