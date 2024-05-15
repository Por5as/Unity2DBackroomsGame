using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private RoomTemplates templates;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.CompareTag("Room") && !(other.CompareTag("SpawnPoint")) && transform.parent != other.gameObject.transform)
        {
            Destroy(other.gameObject);
            Instantiate(templates.closedRoom, transform.position, Quaternion.identity);

        }
        

       
        if (other.CompareTag("ClosedRoom") && !(other.CompareTag("SpawnPoint")) && transform.parent != other.gameObject.transform)
        {
            Destroy(other.gameObject);

        }
        

        if (!other.CompareTag("Player") && transform.parent != other.gameObject.transform)
        {
            Destroy(other.gameObject);

        }
    }
}
