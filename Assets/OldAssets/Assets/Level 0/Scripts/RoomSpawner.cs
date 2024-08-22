
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
	private Transform player;



	void Start()
	{
		randomTime = Random.Range(0.1f, 0.5f);
		player = GameObject.FindGameObjectWithTag("Player").transform;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

		Invoke(nameof(SpawnRoom), randomTime);
    }


    void SpawnRoom()
	{

		if (spawned == false)
		{

            if (Vector2.Distance(transform.position, player.position) < 12)
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
                Invoke(nameof(SpawnRoom), randomTime);

            }

        }
    }
}
