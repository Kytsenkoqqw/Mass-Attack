using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk FirstChunk;
    private float _offset = 25;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    private Chunk LastSpawnedChunk => spawnedChunks[spawnedChunks.Count - 1];
    private Chunk PenultimateSpawnedChunk => spawnedChunks[spawnedChunks.Count - 2];

    private void Start()
    {
        spawnedChunks.Add(Instantiate(FirstChunk));
    }

    private void Update()
    {
        SpawnedChunksBegin();
        SpawnedChunksRight();
        SpawnedChunksLeft();
        SpawnedChunksEnd();
        DestroyChunks();
    }

    private void SpawnedChunksBegin()
    {
        if (Player.position.z > LastSpawnedChunk.Begin.position.z - _offset)
        {
            var newChunk = SpawnNewChunk();
            newChunk.transform.position = PenultimateSpawnedChunk.Begin.position - newChunk.End.localPosition;
        }
    }

    private void  SpawnedChunksRight()
    {
        if (Player.position.x > LastSpawnedChunk.Left.position.x - _offset)
        {
            var newChunk = SpawnNewChunk();
            newChunk.transform.position = PenultimateSpawnedChunk.Left.position - newChunk.Right.localPosition;
        }
        
    }
    
    private void  SpawnedChunksLeft()
    {
        if (Player.position.x < LastSpawnedChunk.Right.position.x + _offset)
        {
            var newChunk = SpawnNewChunk();
            newChunk.transform.position = PenultimateSpawnedChunk.Right.position - newChunk.Left.localPosition;
        }
       
    }

    private void  SpawnedChunksEnd()
    {
        if (Player.position.z < LastSpawnedChunk.End.position.z + _offset)
        {
            var newChunk = SpawnNewChunk();
            newChunk.transform.position = PenultimateSpawnedChunk.End.position - newChunk.Begin.localPosition;
        }
    }

    private Chunk SpawnNewChunk()
    {
        Chunk newChunk = Instantiate(FirstChunk);
        spawnedChunks.Add(newChunk);
        return newChunk;
    }

    private void DestroyChunks()
    {
        if (spawnedChunks[0] != null)
        {
            if (spawnedChunks.Count >= 3)
            {
                Destroy(spawnedChunks[0].gameObject);
                spawnedChunks.RemoveAt(0);
            }
        }
    }
}
