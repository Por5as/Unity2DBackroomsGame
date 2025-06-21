using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenuHide;
    public GameObject PauseMenuOpen;

    public void Continue()
    {
        PauseMenuHide = GameObject.FindGameObjectWithTag("PauseMenu");
        foreach (Transform child in PauseMenuHide.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void PauseMenu()
    {
        PauseMenuOpen = GameObject.FindGameObjectWithTag("PauseMenu");
        foreach (Transform child in PauseMenuOpen.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
