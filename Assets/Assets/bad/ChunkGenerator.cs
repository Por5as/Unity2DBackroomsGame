/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkGenerator : MonoBehaviour
{
    public Tilemap tilemap;

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

    public int chunkSize = 16;

    public void GenerateChunk(int chunkX, int chunkY)
    {
        InitTiles();

        Vector3Int basePos = new Vector3Int(chunkX * chunkSize, chunkY * chunkSize, 0);
        string[,] placedKeys = new string[chunkSize, chunkSize];

        for (int y = 0; y < chunkSize; y++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                string leftKey = x > 0 ? placedKeys[x - 1, y] : null;
                string bottomKey = y > 0 ? placedKeys[x, y - 1] : null;

                var compatible = GetCompatibleTiles(leftKey, bottomKey);
                if (compatible.Count == 0) continue;

                string key = GetWeightedRandomKey(compatible);
                placedKeys[x, y] = key;

                Vector3Int pos = basePos + new Vector3Int(x, y, 0);
                tilemap.SetTile(pos, tileDict[key]);
            }
        }
    }

    void InitTiles()
    {
        if (tileDict.Count > 0) return;

        foreach (var option in tileOptions)
        {
            tileDict[option.key] = option.tile;
            tileWeights[option.key] = Mathf.Max(1, option.weight);
            tileKeys.Add(option.key);
        }
    }

    List<string> GetCompatibleTiles(string leftKey, string bottomKey)
    {
        List<string> result = new();

        foreach (var key in tileKeys)
        {
            bool valid = true;

            if (leftKey != null)
            {
                bool thisHasLeft = key.Contains("L");
                bool leftHasRight = leftKey.Contains("R");

                if (thisHasLeft && !leftHasRight)
                    valid = false;
            }

            if (bottomKey != null)
            {
                bool thisHasBottom = key.Contains("B");
                bool bottomHasTop = bottomKey.Contains("T");

                if (thisHasBottom && !bottomHasTop)
                    valid = false;
            }

            if (valid)
                result.Add(key);
        }

        return result;
    }

    string GetWeightedRandomKey(List<string> compatibleKeys)
    {
        int total = 0;
        foreach (var key in compatibleKeys)
            total += tileWeights[key];

        int roll = Random.Range(0, total);
        int sum = 0;

        foreach (var key in compatibleKeys)
        {
            sum += tileWeights[key];
            if (roll < sum)
                return key;
        }

        return compatibleKeys[0];
    }
}
*/
