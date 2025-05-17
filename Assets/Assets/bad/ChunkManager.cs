/*
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public GameObject chunkPrefab;
    public Transform player;
    public int chunkSize = 16;
    public int viewDistance = 2;

    private Dictionary<Vector2Int, GameObject> loadedChunks = new();

    void Update()
    {
        Vector2Int currentChunk = GetPlayerChunkCoord();

        // Load chunks around the player
        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector2Int coord = currentChunk + new Vector2Int(x, y);

                if (!loadedChunks.ContainsKey(coord))
                {
                    SpawnChunk(coord);
                }
            }
        }

        // Unload distant chunks
        UnloadDistantChunks(currentChunk);
    }

    Vector2Int GetPlayerChunkCoord()
    {
        Vector3 pos = player.position;
        int x = Mathf.FloorToInt(pos.x / chunkSize);
        int y = Mathf.FloorToInt(pos.y / chunkSize);
        return new Vector2Int(x, y);
    }

    void SpawnChunk(Vector2Int coord)
    {
        GameObject chunk = Instantiate(chunkPrefab, Vector3.zero, Quaternion.identity);
        chunk.name = $"Chunk {coord.x},{coord.y}";

        var generator = chunk.GetComponent<DenseWallTileGenerator>();
        if (generator != null)
        {
            generator.GenerateChunk(coord);
        }

        loadedChunks[coord] = chunk;
    }

    void UnloadDistantChunks(Vector2Int center)
    {
        List<Vector2Int> toRemove = new();

        foreach (var pair in loadedChunks)
        {
            Vector2Int coord = pair.Key;
            if (Mathf.Abs(coord.x - center.x) > viewDistance || Mathf.Abs(coord.y - center.y) > viewDistance)
            {
                Destroy(pair.Value);
                toRemove.Add(coord);
            }
        }

        foreach (var coord in toRemove)
        {
            loadedChunks.Remove(coord);
        }
    }
}
*/