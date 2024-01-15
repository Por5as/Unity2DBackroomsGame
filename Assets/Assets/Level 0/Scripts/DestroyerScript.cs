using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player") && transform.parent != other.gameObject.transform) //Added AntiStack and Spawnpoint
		{
			Destroy(other.gameObject);

        }
	//Debug.Log("Destroyed");



	/*
	if (other.CompareTag("Room"))
	{
		Destroy(this.gameObject);
		Debug.Log("Room destroyed");
	}
	*/
	}
}
