using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    InputSystem inputSystem;
    Rigidbody rb;
    Player player;

    Vector2 inputVector;
    private float moveSpeed = 5f;
    private float jumpForce = 5f;
    private void Awake()
    {
        inputSystem=new InputSystem();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputSystem.Player.Enable();
        inputSystem.Player.Jump.started += OnJump;
        inputSystem.Player.Move.performed += OnMove;
        
    }

    private void OnDisable()
    {
        inputSystem.Player.Jump.started-=OnJump;
        inputSystem.Player.Move.performed-=OnMove;
        inputSystem.Disable();
    }

    private void FixedUpdate()
    {
        
    }
    private void Move()
    {
        Vector3 direction=(transform.forward*inputVector.y+transform.right*inputVector.x).normalized;
        direction*=moveSpeed;
        direction.y = rb.velocity.y;
        rb.velocity=direction;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputVector = inputSystem.Player.Move.ReadValue<Vector2>();
            Move();
        }
          

        if (context.canceled)
        {
            inputVector=Vector3.zero;
        }
        
        
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
    }

}
