using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;
	private float randomTime;



    void Start()
	{
		//Destroy(gameObject, waitTime);

		randomTime = Random.Range(0.1f, 0.4f);

    templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        InvokeRepeating("SpawnRoom", randomTime, randomTime);
		//Debug.Log(randomTime);
		
    }


    void SpawnRoom()
	{
		if (spawned == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 8)
		{
			if (openingDirection == 1)
			{
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, transform.rotation = Quaternion.identity);

            }
			else if (openingDirection == 2)
			{
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, transform.rotation = Quaternion.identity);
			}
			else if (openingDirection == 3)
			{
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, transform.rotation = Quaternion.identity);
			}
			else if (openingDirection == 4)
			{
				// Need to spawn a room with a RIGHT door.
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, transform.rotation = Quaternion.identity);
			}
			spawned = true;
		}
		
		else
        {
            Invoke("SpawnRoom", randomTime);
        } 
    }
}
