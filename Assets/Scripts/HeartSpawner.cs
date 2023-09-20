using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnRadius = 10f;
    public float interval = 4f;
    private bool canSpawn = false;
    public Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
        StartCoroutine(EnableSpawning());
    }

    IEnumerator EnableSpawning()
    {
        yield return new WaitForSeconds(2f); 
        canSpawn = true;

        while (canSpawn)
        {
            SpawnObject();
            yield return new WaitForSeconds(interval);
        }
    }

    public void SpawnObject()
    {
        if (canSpawn)
        {
            Vector3 randomCirclePoint = UnityEngine.Random.insideUnitCircle.normalized * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomCirclePoint.x + transform.position.x, transform.position.y,
                randomCirclePoint.y + transform.position.z);
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
