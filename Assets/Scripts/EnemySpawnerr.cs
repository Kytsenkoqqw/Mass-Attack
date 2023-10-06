using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerr : MonoBehaviour
{
    [System.Serializable]
    public struct EnemySpawnInfo
    {
        public Transform spawnPoint; // Точка спавна
        public GameObject enemyPrefab; // Префаб врага
    }

    public EnemySpawnInfo[] spawnPointsAndEnemies; // Массив с информацией о точках спавна и врагах.

    public float spawnInterval = 2f; // Интервал между спавнами.
    private float nextSpawnTime = 0f;

    private void Update()
    {
        // Проверяем, прошло ли достаточно времени для следующего спавна.
        if (Time.time >= nextSpawnTime)
        {
            // Выбираем случайную информацию о спавне.
            EnemySpawnInfo spawnInfo = spawnPointsAndEnemies[Random.Range(0, spawnPointsAndEnemies.Length)];

            // Создаем врага в выбранной точке спавна.
            Instantiate(spawnInfo.enemyPrefab, spawnInfo.spawnPoint.position, spawnInfo.spawnPoint.rotation);

            // Устанавливаем время следующего спавна.
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
