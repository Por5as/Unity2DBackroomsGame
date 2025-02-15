using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSpawnerScript : MonoBehaviour
{
    public Tilemap tilemap; // Assign the Tilemap in the Inspector
    public TileBase[] ruleTiles; // Assign multiple RuleTiles in the Inspector
    public Transform player; // Assign the player's Transform
    public int viewDistance = 10; // Distance in tiles to keep tiles visible
    public int disableDistance = 15; // Distance at which tiles are disabled

    private HashSet<Vector3Int> activeTiles = new HashSet<Vector3Int>(); // Track active tiles
    private HashSet<Vector3Int> disabledTiles = new HashSet<Vector3Int>(); // Track disabled tiles
    private System.Random random = new System.Random(); // Random number generator

    void Update()
    {
        Vector3Int playerPosition = tilemap.WorldToCell(player.position);

        // Loop through a square around the player
        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector3Int tilePosition = new Vector3Int(playerPosition.x + x, playerPosition.y + y, 0);

                if (!activeTiles.Contains(tilePosition) && !disabledTiles.Contains(tilePosition))
                {
                    // Pick a random RuleTile from the array
                    TileBase randomTile = ruleTiles[random.Next(ruleTiles.Length)];

                    // Place the tile
                    tilemap.SetTile(tilePosition, randomTile);
                    activeTiles.Add(tilePosition);
                }
            }
        }

        // Disable tiles that are too far away
        foreach (var tilePos in new HashSet<Vector3Int>(activeTiles))
        {
            if (Vector3Int.Distance(tilePos, playerPosition) > disableDistance)
            {
                tilemap.SetTile(tilePos, null); // Hide the tile by setting it to null
                activeTiles.Remove(tilePos);
                disabledTiles.Add(tilePos); // Track it as disabled
            }
        }

        // Re-enable tiles if they come back into view
        foreach (var tilePos in new HashSet<Vector3Int>(disabledTiles))
        {
            if (Vector3Int.Distance(tilePos, playerPosition) <= viewDistance)
            {
                // Pick a random RuleTile again when re-enabling
                TileBase randomTile = ruleTiles[random.Next(ruleTiles.Length)];
                tilemap.SetTile(tilePos, randomTile);
                disabledTiles.Remove(tilePos);
                activeTiles.Add(tilePos);
            }
        }
    }
}
