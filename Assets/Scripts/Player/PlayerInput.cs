using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.UI.VirtualMouseInput;

public class PlayerInput : MonoBehaviour
{
    
    InputSystem inputSystem;
    Rigidbody rb;
 
    Vector2 inputVector;
    private float moveSpeed =>PlayerManager.instance.player.Speed;
    private float jumpForce = 30f;

    [SerializeField] LayerMask groundLayerMask;
    private bool isGrounded;
    Vector2 cursorMove;
    float maxRot = 180f;
    float minrot = -180f;

    float turnSide;
    float turnUpDown;

    [SerializeField] Transform cameraTransform;

    [Range(0,1)] [SerializeField] float mouseSensitivity;

    

    
    private void OnCameraMove(InputAction.CallbackContext context)
    {
        cursorMove = context.ReadValue<Vector2>();
        
    }
    private void CameraMove()
    {
        Mathf.Clamp(turnSide, minrot, maxRot);
        Mathf.Clamp(turnUpDown, minrot, maxRot);
        //cameraTransform.Rotate(Vector3.up * cursorMove.x);

        turnSide += cursorMove.x * mouseSensitivity;
        turnUpDown -= cursorMove.y*mouseSensitivity;

        transform.rotation = Quaternion.Euler(0, turnSide, 0);
        cameraTransform.localRotation = Quaternion.Euler(turnUpDown, 0, 0);
    }
    private void Awake()
    {
        inputSystem=new InputSystem();
        
        rb = GetComponent<Rigidbody>();
        PlayerManager.instance.playerInput = this;
    }

    private void OnEnable()
    {
        inputSystem.Player.Enable();

        inputSystem.Player.Jump.started += OnJump;
        inputSystem.Player.Move.performed += OnMove;
        inputSystem.Player.Move.canceled+= OnMove;
        inputSystem.Player.CameraMove.performed += OnCameraMove;
        inputSystem.Player.CameraMove.canceled += OnCameraMove;
        inputSystem.Player.Inventory.started += OnInventory;
        inputSystem.UI.CloseInventory.started += OnCloseInventory;


    }

    private void OnDisable()
    {
        inputSystem.Player.Jump.started-=OnJump;
        inputSystem.Player.Move.performed-=OnMove;
        inputSystem.Player.Move.canceled -= OnMove;
        inputSystem.Player.CameraMove.performed -= OnCameraMove;
        inputSystem.Player.CameraMove.canceled -= OnCameraMove;
        inputSystem.Player.Inventory.started -= OnInventory;
        inputSystem.UI.CloseInventory.started -= OnCloseInventory;



        inputSystem.Disable();
    }

    private void Update()
    {
        Move();
        CameraMove();
        if (Physics.Raycast(transform.position, Vector3.down, 1f, groundLayerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
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
        
            inputVector = inputSystem.Player.Move.ReadValue<Vector2>();  
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if(isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        UIManager.Instance.ChangeUI(UIState.InventoryUI,true);
        inputSystem.Player.Disable();
        inputSystem.UI.Enable();
        
    }
    private void OnCloseInventory(InputAction.CallbackContext context)
    {
        UIManager.Instance.ChangeUI(UIState.InventoryUI, false);
        inputSystem.UI.Disable();
        inputSystem.Player.Enable();
        
    }
    

}
