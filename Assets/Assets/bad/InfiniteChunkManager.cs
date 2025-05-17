/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteChunkManager : MonoBehaviour
{
    public GameObject chunkPrefab; // Prefab with a Tilemap + Generator component
    public Transform player;

    public int chunkSize = 16;
    public int loadRadius = 2; // 1 = 3x3 chunks around player

    private Dictionary<Vector2Int, GameObject> loadedChunks = new();

    private Vector2Int currentPlayerChunk;

    void Start()
    {
        UpdateChunks(forceUpdate: true);
    }

    void Update()
    {
        Vector2Int newChunk = GetPlayerChunkCoord();
        if (newChunk != currentPlayerChunk)
        {
            currentPlayerChunk = newChunk;
            UpdateChunks();
        }
    }

    Vector2Int GetPlayerChunkCoord()
    {
        Vector3 pos = player.position;
        int cx = Mathf.FloorToInt(pos.x / chunkSize);
        int cy = Mathf.FloorToInt(pos.y / chunkSize);
        return new Vector2Int(cx, cy);
    }

    void UpdateChunks(bool forceUpdate = false)
    {
        Vector2Int playerChunk = GetPlayerChunkCoord();
        HashSet<Vector2Int> needed = new();

        // Figure out which chunks should be loaded
        for (int dx = -loadRadius; dx <= loadRadius; dx++)
        {
            for (int dy = -loadRadius; dy <= loadRadius; dy++)
            {
                Vector2Int coord = new Vector2Int(playerChunk.x + dx, playerChunk.y + dy);
                needed.Add(coord);

                if (!loadedChunks.ContainsKey(coord))
                {
                    GameObject newChunk = Instantiate(chunkPrefab, new Vector3(coord.x * chunkSize, coord.y * chunkSize, 0), Quaternion.identity);
                    newChunk.name = $"Chunk_{coord.x}_{coord.y}";
                    newChunk.GetComponent<ChunkGenerator>().GenerateChunk(coord.x, coord.y);
                    loadedChunks[coord] = newChunk;
                }
            }
        }

        // Unload chunks that are no longer needed
        List<Vector2Int> toRemove = new();
        foreach (var kvp in loadedChunks)
        {
            if (!needed.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                toRemove.Add(kvp.Key);
            }
        }

        foreach (var key in toRemove)
        {
            loadedChunks.Remove(key);
        }
    }
}
*/