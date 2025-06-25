
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLoadingScreen : MonoBehaviour
{

    void Start()
    {
        Invoke(nameof(RemoveLoadScreen), 3f);
    }

    void RemoveLoadScreen()
    {
        Destroy(this.gameObject);
    }
}
