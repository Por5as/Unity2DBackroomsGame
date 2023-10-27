using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedAntistack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Room") && !(other.CompareTag("SpawnPoint")) && transform.parent != other.gameObject.transform)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed");

        }

    }
}
