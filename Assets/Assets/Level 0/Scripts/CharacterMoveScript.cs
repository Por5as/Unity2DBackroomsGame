using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMoveScript : MonoBehaviour
{

    public Vector2 movementDirection;
    public float movementSpeed;
    public Rigidbody2D rb;
    public float MOVEMENT_BASE_SPEED = 1.25f;
    public Animator animator;

    void Start()
    {
        InvokeRepeating(nameof(Unlag), 5.0f, 30f);
        //InvokeRepeating("Unlag", 5.0f, 30f);
    }

    void Unlag()
    {
        Resources.UnloadUnusedAssets();
    }

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
        rb.velocity = MOVEMENT_BASE_SPEED * movementSpeed * movementDirection;
        //rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
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
