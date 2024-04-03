using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLoadingScreen : MonoBehaviour
{

    private GameObject LoadScreen;
    void Start()
    {
        Invoke("RemoveLoadScreen", 5f);
    }

    void RemoveLoadScreen()
    {
        LoadScreen = GameObject.FindGameObjectWithTag("LoadScreen");
        Destroy(LoadScreen);
    }
}
