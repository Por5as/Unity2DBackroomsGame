
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisableFarRooms : MonoBehaviour
{
    private GameObject player;
    private readonly GameObject[] rooms;

    void Start()
    {
        InvokeRepeating(nameof(Script), 6f, 1f);
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Script()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("RoomParent");

        foreach (GameObject room in rooms)
        {
            if (room.transform.childCount >= 1){
                    if (room.transform.GetChild(0).gameObject.activeInHierarchy == true && Vector2.Distance(room.transform.position, player.transform.position) > 13)
                {
                    room.transform.GetChild(0).gameObject.SetActive(false);

                }

                else if (room.transform.GetChild(0).gameObject.activeInHierarchy == false && Vector2.Distance(room.transform.position, player.transform.position) < 11)
                {
                    room.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }
}