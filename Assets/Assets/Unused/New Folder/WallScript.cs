using UnityEngine;
using UnityEngine.Tilemaps;

public class WallScript : MonoBehaviour
{
    public GameObject objectToInstantiate;  // The 3D GameObject to instantiate
    public LayerMask colliderLayer;  // Layer mask to target only certain colliders (optional)

    void Start()
    {
        Debug.Log("Started");
        // Get all CompositeCollider2D components in the scene
        TilemapCollider2D[] colliders = FindObjectsOfType<TilemapCollider2D>();

        foreach (var collider in colliders)
        {
            
            // Instantiate the 3D object at the position of the collider
            GameObject instantiatedObject = Instantiate(objectToInstantiate, collider.transform.position, Quaternion.identity);

            // Get the bounds of the 2D collider
            Bounds colliderBounds = collider.bounds;

            // Convert the 2D bounds to 3D space
            Vector3 size = new Vector3(colliderBounds.size.x, colliderBounds.size.y, 1);

            // Set the size of the instantiated object to match the collider's size
            instantiatedObject.transform.localScale = size;
            Debug.Log("Spawned");

        }
    }
}
