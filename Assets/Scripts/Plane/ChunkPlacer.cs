using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;
    
    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    private void Update()
    {
        if (Player.position.z > spawnedChunks[spawnedChunks.Count - 1].End.position.z)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);
    }
}
