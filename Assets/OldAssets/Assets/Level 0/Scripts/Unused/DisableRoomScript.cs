
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoomScript : MonoBehaviour
{ }
    /*
    private Transform objects;
    private GameObject player;

    void Start()
    {
        Invoke(nameof(Script), 1f);
        objects = GameObject.FindGameObjectWithTag("Room").transform.GetChild(0);
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Script()
    {
        foreach (Transform child in transform)
        {
            //if (child.gameObject.activeInHierarchy == true && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 15) //---------PC
            if (objects.gameObject.activeSelf == true && Vector2.Distance(transform.position, player.transform.position) > 8) //----Mobile
            {
                child.gameObject.SetActive(false);
                //Debug.Log("Inactive");
            }

            else if (objects.gameObject.activeSelf == false && Vector2.Distance(transform.position, player.transform.position) > 8) //----Mobile
            {
                child.gameObject.SetActive(true);
                //Debug.Log("Inactive");
            }

            //else if (child.gameObject.activeInHierarchy == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 12) //------PC
             //if (child.gameObject.transform.GetChild(0).gameObject.activeSelf == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 7) //--Mobile
            
                //child.gameObject.transform.GetChild(0).gameObject.activeSelf == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 7; //--Mobile
                
                //Debug.Log("Active");
            
        }
        Invoke(nameof(Script), 1f);
    }

}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoomScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Script());
    }

    IEnumerator Script()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (Transform child in transform)
        {
            //if (child.gameObject.activeInHierarchy == true && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 15) //---------PC
            if (child.gameObject.transform.GetChild(0).gameObject.activeSelf == true && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 8) //----Mobile
            {
                child.gameObject.SetActive(false);
                //Debug.Log("Inactive");
            }

            else if (child.gameObject.transform.GetChild(0).gameObject.activeSelf == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 8) //----Mobile
            {
                child.gameObject.SetActive(true);
                //Debug.Log("Inactive");
            }

            //else if (child.gameObject.activeInHierarchy == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 12) //------PC
            else //if (child.gameObject.transform.GetChild(0).gameObject.activeSelf == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 7) //--Mobile
            {
                //child.gameObject.transform.GetChild(0).gameObject.activeSelf == false && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 7; //--Mobile
                yield return null;
                //Debug.Log("Active");
            }
        }
        StartCoroutine(Script());
    }
    
}
*/