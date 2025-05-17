/*
    using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DenseWallTileGenerator : MonoBehaviour
{
    public int width = 20;
    public int height = 20;

    public Tilemap tilemap;

    [System.Serializable]
    public class TileOption
    {
        public string key;      // e.g. "L", "TR", "LTRB", ""
        public TileBase tile;
        public int weight = 1;  // Higher weight = more likely to be chosen
    }

    public TileOption[] tileOptions;

    private Dictionary<string, TileBase> tileDict = new();
    private Dictionary<string, int> tileWeights = new();
    private List<string> tileKeys = new();

    private string[,] placedKeys;

    void Start()
    {
        foreach (var option in tileOptions)
        {
            tileDict[option.key] = option.tile;
            tileWeights[option.key] = Mathf.Max(1, option.weight);
            tileKeys.Add(option.key);
        }

        GenerateMap();
    }

    void GenerateMap()
    {
        tilemap.ClearAllTiles();
        placedKeys = new string[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                string leftKey = x > 0 ? placedKeys[x - 1, y] : null;
                string bottomKey = y > 0 ? placedKeys[x, y - 1] : null;

                List<string> compatible = GetCompatibleTiles(leftKey, bottomKey);
                if (compatible.Count == 0) continue;

                string chosenKey = GetWeightedRandomKey(compatible);
                placedKeys[x, y] = chosenKey;
                tilemap.SetTile(pos, tileDict[chosenKey]);
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
*/