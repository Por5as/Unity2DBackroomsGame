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
        movementDirection = new Vector2(0.0f, 0.0f);
        InvokeRepeating(nameof(Unlag), 10, 30);
    }

    void Update()
    {
        ProcessInput();
        Move();
        Animate();
    }

    void Unlag()
    {
        Resources.UnloadUnusedAssets();
    }

    void ProcessInput()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.y = Input.GetAxis("Vertical");

        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move()
    {
        rb.velocity = MOVEMENT_BASE_SPEED * movementSpeed * movementDirection;
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
