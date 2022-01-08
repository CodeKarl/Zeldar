using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character attributes:")]
    public float MOVEMENT_BASE_SPEED = 3.0f;

    [Space]
    [Header("Movement statistics:")]
    public float movementSpeed;
    public Vector2 movementDirection;

    [Space]
    [Header("References:")]
    public Rigidbody2D rigidBody;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        ProcessInputs();
        Move();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        animator.SetFloat("Movement Speed", movementSpeed);
    }

    void Move()
    {
        rigidBody.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }
}
