using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteTilemapChunkLoader : MonoBehaviour
{
    [Header("References")]
    public Tilemap tilemap;
    public Transform player;

    [Header("Settings")]
    public int chunkSize = 16;
    public int viewDistance = 2;


    [System.Serializable]
    public class TileOption
    {
        public string key;
        public TileBase tile;
        public int weight = 1;
    }

    public TileOption[] tileOptions;

    private Dictionary<string, TileBase> tileDict = new();
    private Dictionary<string, int> tileWeights = new();
    private List<string> tileKeys = new();

    private HashSet<Vector2Int> loadedChunks = new();
    private Dictionary<Vector2Int, Dictionary<Vector3Int, TileBase>> savedChunks = new();

    private string[,] placedKeys;
    private Vector2Int currentGeneratingChunkCoord;

    void Start()
    {
        foreach (var opt in tileOptions)
        {
            tileDict[opt.key] = opt.tile;
            tileWeights[opt.key] = Mathf.Max(1, opt.weight);
            tileKeys.Add(opt.key);
        }
    }

    void Update()
    {
        Vector2Int currentChunk = GetPlayerChunkCoord();

        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector2Int coord = currentChunk + new Vector2Int(x, y);
                if (!loadedChunks.Contains(coord))
                {
                    currentGeneratingChunkCoord = coord;
                    GenerateChunk(coord);
                    loadedChunks.Add(coord);
                }
            }
        }

        UnloadDistantChunks(currentChunk);
    }

    Vector2Int GetPlayerChunkCoord()
    {
        Vector3 pos = player.position;
        int x = Mathf.FloorToInt(pos.x / chunkSize);
        int y = Mathf.FloorToInt(pos.y / chunkSize);
        return new Vector2Int(x, y);
    }

    void GenerateChunk(Vector2Int chunkCoord)
    {
        if (savedChunks.TryGetValue(chunkCoord, out var saved))
        {
            foreach (var kvp in saved)
            {
                tilemap.SetTile(kvp.Key, kvp.Value);
            }
            return;
        }

        placedKeys = new string[chunkSize, chunkSize];
        Dictionary<Vector3Int, TileBase> tiles = new();

        for (int y = 0; y < chunkSize; y++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                Vector3Int pos = new Vector3Int(
                    chunkCoord.x * chunkSize + x,
                    chunkCoord.y * chunkSize + y,
                    0
                );

                string leftKey = x > 0 ? placedKeys[x - 1, y] : null;
                string bottomKey = y > 0 ? placedKeys[x, y - 1] : null;

                List<string> compatible = GetCompatibleTiles(leftKey, bottomKey);
                if (compatible.Count == 0) continue;

                string chosenKey = GetWeightedRandomKey(compatible);
                placedKeys[x, y] = chosenKey;

                TileBase tile = tileDict[chosenKey];
                tilemap.SetTile(pos, tile);
                tiles[pos] = tile;
            }
        }

        savedChunks[chunkCoord] = tiles;
    }

    void UnloadDistantChunks(Vector2Int center)
    {
        List<Vector2Int> toRemove = new();

        foreach (var chunk in loadedChunks)
        {
            if (Mathf.Abs(chunk.x - center.x) > viewDistance || Mathf.Abs(chunk.y - center.y) > viewDistance)
            {
                ClearChunkTiles(chunk);
                toRemove.Add(chunk);
            }
        }

        foreach (var c in toRemove)
            loadedChunks.Remove(c);
    }

    void ClearChunkTiles(Vector2Int chunkCoord)
    {
        for (int y = 0; y < chunkSize; y++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                Vector3Int pos = new Vector3Int(
                    chunkCoord.x * chunkSize + x,
                    chunkCoord.y * chunkSize + y,
                    0
                );
                tilemap.SetTile(pos, null);
            }
        }
    }

    List<string> GetCompatibleTiles(string leftKey, string bottomKey)
    {
        List<string> result = new();

        foreach (string key in tileKeys)
        {
            bool valid = true;

            if (leftKey != null)
            {
                bool thisHasLeftWall = key.Contains("L");
                bool leftHasRightWall = leftKey.Contains("R");
                if (thisHasLeftWall && !leftHasRightWall)
                    valid = false;
            }

            if (bottomKey != null)
            {
                bool thisHasBottomWall = key.Contains("B");
                bool bottomHasTopWall = bottomKey.Contains("T");
                if (thisHasBottomWall && !bottomHasTopWall)
                    valid = false;
            }

            if (valid)
                result.Add(key);
        }

        return result;
    }

    string GetWeightedRandomKey(List<string> compatibleKeys)
    {
        int totalWeight = 0;
        foreach (var key in compatibleKeys)
            totalWeight += tileWeights[key];

        int roll = Random.Range(0, totalWeight);
        int cumulative = 0;

        foreach (var key in compatibleKeys)
        {
            cumulative += tileWeights[key];
            if (roll < cumulative)
                return key;
        }

        return compatibleKeys[0]; // fallback
    }
}
