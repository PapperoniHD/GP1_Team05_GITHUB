using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerTwoInputScript : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput _playerInput;
    
    //Groundcheck
    public Transform groundCheck;
    private float groundDistance = 1f;
    public LayerMask groundMask;
    public bool isGrounded;
    
    //Movement and Gravity variables
    float gravity = 9.81f;
    public float gravityMultiplier = 1;
    public float moveSpeed = 6;
    private float _movementMultiplier = 10;
    float rbDrag = 6f;
    public float jumpForce = 3000;
    private PlayerTwoController playerController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        PlayerOne();
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        
        
    }

    private void FixedUpdate()
    {
        
    }

    void PlayerOne()
    {
        _playerInput = GetComponent<PlayerInput>();

        //_playerInput.onActionTriggered += PlayerInput_onActionTriggered;

        playerController = new PlayerTwoController();
        playerController.Player.Enable(); 
        playerController.Player.Jump.performed += Jump;
        playerController.Player.Move.performed += Movement_performed;
        
    }

 
    

    // Update is called once per frame
    void Update()
    {
        Movement();
        ControlDrag();
        HandleGravity();
        print(rb.drag);
    }

    void Movement()
    {
        
            Vector2 inputVector = playerController.Player.Move.ReadValue<Vector2>();
            rb.AddForce(new Vector3(inputVector.x,0,inputVector.y).normalized * moveSpeed * _movementMultiplier, ForceMode.Acceleration);

    }

    void HandleGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            rb.AddForce(new Vector3(0, (-gravity * gravityMultiplier), 0) * rb.mass);
            
        }
        
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
            if (isGrounded)
            {
                Debug.Log("Jump");
                rb.AddForce(new Vector3(0, jumpForce, 0) * rb.mass);
            }

        }
    }
    
    void ControlDrag()
    {
        rb.drag = rbDrag;
    }
    
}
