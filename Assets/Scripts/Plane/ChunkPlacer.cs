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
    
    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        Instantiate(FirstChunk);
        spawnedChunks.Add(FirstChunk);
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
        if (Player.position.z > spawnedChunks[spawnedChunks.Count - 1].Begin.position.z - 25)
        {
            Chunk newChunk = Instantiate(FirstChunk);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].Begin.position - newChunk.End.localPosition;
            spawnedChunks.Add(newChunk);
        }
        
    }

    public void  SpawnedChunksRight()
    {
        if (Player.position.x > spawnedChunks[spawnedChunks.Count - 1].Left.position.x - 25)
        {
            Chunk newChunk = Instantiate(FirstChunk);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].Left.position - newChunk.Right.localPosition;
            spawnedChunks.Add(newChunk);
        }
        
    }
    
    public void  SpawnedChunksLeft()
    {
        if (Player.position.x < spawnedChunks[spawnedChunks.Count - 1].Right.position.x + 25)
        {
            Chunk newChunk = Instantiate(FirstChunk);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].Right.position - newChunk.Left.localPosition;
            spawnedChunks.Add(newChunk);
        }
       
    }
    
    public void  SpawnedChunksEnd()
    {
        if (Player.position.z < spawnedChunks[spawnedChunks.Count - 1].End.position.z + 25)
        {
            Chunk newChunk = Instantiate(FirstChunk);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            spawnedChunks.Add(newChunk);
        }
    }

    private void DestroyChunks()
    {
        if (spawnedChunks[0] != null)
        {
            if (spawnedChunks.Count >= 20)
            {
                Destroy(spawnedChunks[0].gameObject);
                spawnedChunks.RemoveAt(0);
            }
        }
        else return;
        
    }
}
