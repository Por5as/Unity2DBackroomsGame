using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiEscape : MonoBehaviour
{
    [SerializeField] private LayerMask movableLayer;

    private Vector3 inputVector;

    void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");

        Debug.DrawLine(transform.position + inputVector * .5f, transform.position, Color.cyan);

        if (Physics2D.OverlapPoint(transform.position + inputVector * .5f, movableLayer.value))
        {
            transform.position += inputVector * Time.deltaTime;
        }
    }
}
