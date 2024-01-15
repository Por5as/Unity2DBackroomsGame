using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementspeed = 2f;


    private Rigidbody2D rb;
    //private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /*
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementspeed;
    }

    */

    [SerializeField] private LayerMask movableLayer;

    private Vector3 inputVector;

    void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");

        rb.velocity = inputVector * movementspeed;

        /*Debug.DrawLine(transform.position + inputVector * .2f, transform.position, Color.cyan);

        if (Physics2D.OverlapPoint(transform.position + inputVector * .2f, movableLayer.value))
        {
            rb.velocity = inputVector * movementspeed;
        }
        */
    }

}
