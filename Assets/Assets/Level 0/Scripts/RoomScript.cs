using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private RoomTemplates templates;

    void Start()
    {
        // Find and cache the RoomTemplates component once during Start
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (templates == null)
        {
            Debug.LogError("RoomTemplates component not found! Ensure it's attached to a GameObject with the tag 'Rooms'.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
         * // Check if templates is null before proceeding
        if (templates == null)
        {
            Debug.LogWarning("RoomTemplates reference is null. Cannot proceed with room management.");
            return;
        }
        */

        // Destroy other.gameObject based on its tag and relationship to the current room
        if (other.CompareTag("Room") && !other.CompareTag("SpawnPoint") && transform.parent != other.gameObject.transform)
        {
            DestroyRoom(other.gameObject, templates.closedRoom);
        }
        else if (other.CompareTag("ClosedRoom") && !other.CompareTag("SpawnPoint") && transform.parent != other.gameObject.transform)
        {
            DestroyRoom(other.gameObject);
        }
        else if (!other.CompareTag("Player") && transform.parent != other.gameObject.transform)
        {
            DestroyRoom(other.gameObject);
        }
    }

    // Method to destroy room and optionally instantiate a replacement
    private void DestroyRoom(GameObject room, GameObject replacement = null)
    {
        Destroy(room);

        // Instantiate replacement if provided
        if (replacement != null)
        {
            Instantiate(replacement, transform.position, Quaternion.identity);
        }
    }
}