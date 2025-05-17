using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] ruleTiles;
    public Transform player;
    public int viewDistance = 10;
    public int disableDistance = 15;

    public TileBase specialTile; // <-- Special tile for around spawn
    public int specialAreaRadius = 3; // <-- Radius around (0,0) to protect

    private HashSet<Vector3Int> activeTiles = new HashSet<Vector3Int>();
    private HashSet<Vector3Int> disabledTiles = new HashSet<Vector3Int>();
    private Dictionary<Vector3Int, TileBase> tileMemory = new Dictionary<Vector3Int, TileBase>();
    private System.Random random = new System.Random();

    private bool specialTilesPlaced = false; // <-- Track if we placed special tiles

    void Start()
    {
        StartCoroutine(PlaceSpecialTilesAfterDelay(0.5f)); // <-- Wait 1 second after start
    }

    void Update()
    {
        Vector3Int playerPosition = tilemap.WorldToCell(player.position);

        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector3Int tilePosition = new Vector3Int(playerPosition.x + x, playerPosition.y + y, 0);

                if (!activeTiles.Contains(tilePosition) && !disabledTiles.Contains(tilePosition))
                {
                    TileBase chosenTile;

                    // Check if this position was already assigned a tile before
                    if (!tileMemory.TryGetValue(tilePosition, out chosenTile))
                    {
                        // Random tile generation, but skip if special tile is reserved
                        if (IsWithinSpecialArea(tilePosition) && !specialTilesPlaced)
                        {
                            // Do not assign random tile yet
                            continue;
                        }

                        // Otherwise assign random tile
                        chosenTile = ruleTiles[random.Next(ruleTiles.Length)];
                        tileMemory[tilePosition] = chosenTile;
                    }

                    tilemap.SetTile(tilePosition, chosenTile);
                    activeTiles.Add(tilePosition);
                }
            }
        }

        // Disable tiles that are too far away
        foreach (var tilePos in new HashSet<Vector3Int>(activeTiles))
        {
            if (Vector3Int.Distance(tilePos, playerPosition) > disableDistance)
            {
                tilemap.SetTile(tilePos, null);
                activeTiles.Remove(tilePos);
                disabledTiles.Add(tilePos);
            }
        }

        // Re-enable tiles if they come back into view
        foreach (var tilePos in new HashSet<Vector3Int>(disabledTiles))
        {
            if (Vector3Int.Distance(tilePos, playerPosition) <= viewDistance)
            {
                TileBase storedTile = tileMemory[tilePos];
                tilemap.SetTile(tilePos, storedTile);

                disabledTiles.Remove(tilePos);
                activeTiles.Add(tilePos);
            }
        }
    }

    private bool IsWithinSpecialArea(Vector3Int pos)
    {
        return Vector3Int.Distance(Vector3Int.zero, pos) <= specialAreaRadius;
    }

    private IEnumerator PlaceSpecialTilesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int x = -specialAreaRadius; x <= specialAreaRadius; x++)
        {
            for (int y = -specialAreaRadius; y <= specialAreaRadius; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                tilemap.SetTile(tilePosition, specialTile);
                tileMemory[tilePosition] = specialTile; // Memorize that it's a special tile
                activeTiles.Add(tilePosition);
                disabledTiles.Remove(tilePosition); // If it was disabled for some reason
            }
        }

        specialTilesPlaced = true; // Now random generation can happen
    }
}
