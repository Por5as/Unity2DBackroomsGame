using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Vector2 movementDirection;
    public float movementSpeed;
    public Rigidbody2D rb;
    public float MOVEMENT_BASE_SPEED = 1.25f;
    public Animator animator;

    void Update()
    {
        ProcessInput();
        Move();
        Animate();
    }

    void ProcessInput()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);

    }

}
