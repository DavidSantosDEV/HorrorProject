using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField][Range(1,10)] private float movementSpeed=1;

    private Rigidbody2D body;

    private Vector2 movementInput;
    private void Awake()
    {
        body=GetComponent<Rigidbody2D>();
    }

    public void UpdateInput(Vector2 input)
    {
        movementInput = input;
    }

    private void FixedUpdate()
    {
        body.velocity = movementInput * movementSpeed;
    }
}
