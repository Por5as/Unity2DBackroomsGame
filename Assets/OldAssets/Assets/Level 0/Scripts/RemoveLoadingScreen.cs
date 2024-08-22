
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLoadingScreen : MonoBehaviour
{

    private GameObject LoadScreen;
    void Start()
    {
        LoadScreen = GameObject.FindGameObjectWithTag("LoadScreen");
        Invoke(nameof(RemoveLoadScreen), 7f);
    }

    void RemoveLoadScreen()
    {
        Destroy(LoadScreen);
    }
}
