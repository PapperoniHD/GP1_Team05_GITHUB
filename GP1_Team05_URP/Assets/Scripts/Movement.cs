using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{

    private PlayerController playerControls;
    
    Rigidbody rb;
    public Transform groundCheck;
    
    float horizontalMovement;
    float verticalMovement;
    
    
    
    private Vector3 moveDirection;

    private float groundDistance = 0.5f;
    public LayerMask groundMask;

    public bool isGrounded;

    private void Awake()
    {
        playerControls = new PlayerController();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        print(rb.velocity);
        InputManager();
        ControlDrag();
        HandleGravity();

        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
    }

    void InputManager()
    {
        //Inputs for movement
        if (this.gameObject.tag == "Player2")
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal2");
            verticalMovement = Input.GetAxisRaw("Vertical2");
        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");
        }
        
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
        
        //Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();

    }

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * _movementMultiplier, ForceMode.Acceleration);
    }
    
    public float gravity = -9.81f;
    public float moveSpeed = 6;
    private float _movementMultiplier = 10;
    float rbDrag = 6f;
    public float jumpForce = 10;
    void HandleGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            rb.AddForce(new Vector3(0, gravity, 0) * rb.mass);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0) * rb.mass);
        }
        
    }
}
