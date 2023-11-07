using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 4f;
    private float timeSinceLastSpawn = 0f;
    private PlayerController player;
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
        if (player != null)
        {
            float spawnRadius = 30f; // Радиус, в котором будут спавниться враги относительно игрока
            Vector3 randomCirclePoint = UnityEngine.Random.insideUnitCircle.normalized * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomCirclePoint.x + player.transform.position.x, player.transform.position.y, randomCirclePoint.y + player.transform.position.z);
            var newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

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
