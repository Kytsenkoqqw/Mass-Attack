using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOfTheDead : MonoBehaviour
{
    public GameObject summonPrefab;
    public Transform playerTransform;
    public float summonSpawnDistance = 2f;

    private void Start()
    {
        // Подписываемся на событие нажатия кнопки
        Button bookButton = GetComponent<Button>();
        bookButton.onClick.AddListener(SpawnSummons);
    }

    private void SpawnSummons()
    {
        // Вычисляем позицию спауна рядом с героем
        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * summonSpawnDistance;

        // Создаем двух самонов
        GameObject summon1 = Instantiate(summonPrefab, spawnPosition, Quaternion.identity);
        GameObject summon2 = Instantiate(summonPrefab, spawnPosition, Quaternion.identity);
    }
}
