using UnityEngine;
using System.Collections.Generic;

public class WorldBuilder : MonoBehaviour
{
    public GameObject roomPrefab;
    public Vector2Int chunksSize;
    public Vector2Int roomSize;

    private List<GameObject> chunks = new List<GameObject>();

    private void Start()
    {
        GenerateChunk();
    }

    private void GenerateChunk()
    {
        // create a new empty game object to hold the chunk
        var chunk = new GameObject();
        chunk.name = "Chunk";
        chunks.Add(chunk);

        // generate rooms in the chunk
        for (int x = 0; x < chunksSize.x; x++)
        {
            for (int y = 0; y < chunksSize.y; y++)
            {
                GenerateRoom(chunk.transform, new Vector3(x * roomSize.x, 0, y * roomSize.y));
            }
        }
    }

    private void GenerateRoom(Transform parent, Vector3 position)
    {
        // instantiate the prefab tile at the given position
        var room = Instantiate(roomPrefab, position, Quaternion.identity);
        // parent the room to the chunk
        room.transform.parent = parent;
    }
}
