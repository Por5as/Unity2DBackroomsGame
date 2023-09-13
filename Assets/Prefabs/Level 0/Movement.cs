using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask movableLayer;
    void Update()
    {
        if (Physics2D.OverlapPoint(transform.position, movableLayer))
        {
            Debug.Log("<color=#51FF56>Character can move here...</color>");
        }
        else
        {
            Debug.Log("<color=#FF3854>Character can't move here...</color>");
        }
    }
}
