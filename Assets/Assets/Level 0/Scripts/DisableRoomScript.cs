using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoomScript : MonoBehaviour
{
    
    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy == true && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 15) //---------PC
            //if (child.gameObject.activeSelf == true && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 9) //----Mobile
            {
                child.gameObject.SetActive(false);
                //Debug.Log("Inactive");
            }
        
            else if (child.gameObject.activeInHierarchy == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 12) //------PC
            //else if (child.gameObject.activeSelf == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 8) //--Mobile
            {
                child.gameObject.SetActive(true);
                //Debug.Log("Active");
            }
        }
    }
    
}
