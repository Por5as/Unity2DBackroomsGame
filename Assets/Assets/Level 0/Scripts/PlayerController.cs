using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementspeed = 1f;


    public Rigidbody2D rb;
    private Vector2 moveInput;

    //private Vector2 movementDirection;
    /*
    void Start()
    {
        
    }
    */

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



   

    void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //moveInput.Normalize(); ----------------------------------------------------------------- NEEDS TO BE FIXED --------------------------------------------------------------------------------------------------------------------

        rb.velocity = moveInput * movementspeed;

       
        
        
        /*Debug.DrawLine(transform.position + inputVector * .2f, transform.position, Color.cyan);

        if (Physics2D.OverlapPoint(transform.position + inputVector * .2f, movableLayer.value))
        {
            rb.velocity = inputVector * movementspeed;
        }
        */
    }

}
