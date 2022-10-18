using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputScript : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput _playerInput;
    private Transform playerTransform;
    
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
    private PlayerController playerController;
    private Vector2 movementInput;
    
    //Rotation
    private float _yRotation;
    private float _zRotation;
    
    //Jumping
    private float _jumpBuffer;
    
    
    [SerializeField ] private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        
        
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        
        
    }

    private void FixedUpdate()
    {
        
    }

    void EnableInput()
    {
        _playerInput = GetComponent<PlayerInput>();

        //_playerInput.onActionTriggered += PlayerInput_onActionTriggered;
        
        
        playerController = new PlayerController();
        playerController.Player.Enable(); 
        //playerController.Player.Jump.performed += Jump;
        playerController.Player.Move.performed += Movement_performed;
        
    }

 
    

    // Update is called once per frame
    void Update()
    {
        HandleGravity();
        HandleSubmerge();
        Movement();
        ControlDrag();
        rb.freezeRotation = true;
        RotatePlayer();
        JumpAction();

        print("Is grounded =" + isGrounded);

        if (GameObject.Find("DeathManager").GetComponent<DeathManager>().gameOver == true)
        {
            playerController.Disable();
        }
    }


    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    void Movement()
    {
        
            //Vector2 inputVector = playerController.Player.Move.ReadValue<Vector2>();
            if (isGrounded)
            {
                rb.AddForce(new Vector3(0,0,movementInput.y).normalized * moveSpeed * _movementMultiplier * Time.deltaTime, ForceMode.Acceleration);
            }
            
            
            rb.AddForce(new Vector3(movementInput.x,0,0).normalized * moveSpeed * (_movementMultiplier * 1.5f ) *Time.deltaTime, ForceMode.Acceleration);
            

    }

    void HandleGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            
            rb.AddForce(new Vector3(0, -gravity * gravityMultiplier, 0) * rb.mass * Time.deltaTime, ForceMode.Acceleration);
            
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.9f, rb.velocity.z);
            }
        }
        
        
    }

    void HandleSubmerge()
    {
        if (playerTransform.position.y < 12)
        {
            rb.AddForce(new Vector3(0, gravity * (gravityMultiplier), 0) * rb.mass * Time.deltaTime, ForceMode.Acceleration);
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
            _jumpBuffer = 1f;
        }
    }

    private void JumpAction()
    {
        if (isGrounded && _jumpBuffer > 0)
        {
            rb.constraints = RigidbodyConstraints.None;
            Debug.Log("Jump");
          
            var newJumpForce = Mathf.Sqrt(jumpForce * -2f * -gravity) * rb.mass;
            rb.velocity = new Vector3(rb.velocity.x, newJumpForce, rb.velocity.z);

            _jumpBuffer = 0f;
            AudioManager.Instance.PlaySFX("Jump");
        }

        if (_jumpBuffer > 0) _jumpBuffer -= 5f * Time.deltaTime;
    }
    
    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    

    private void OnEnable()
    {
        GameObject.FindWithTag("Start").GetComponent<StartGame>().playerJoined = true;
        GameObject.Find("DeathManager").GetComponent<DeathManager>().playerAlive++;
        GameObject.Find("DeathManager").GetComponent<DeathManager>().playerSpawned = true;
        
        
        EnableInput();
    }

    private void OnDisable()
    {
        playerController.Player.Disable(); 
    }

    void RotatePlayer()
    {
        Vector3 direction = new Vector3(movementInput.x, 0, 0).normalized;
        var child = transform.GetChild(1).transform;
        
        float targetAngleX = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * 0.3f;
        _yRotation = Mathf.SmoothDampAngle(child.eulerAngles.y, targetAngleX, ref turnSmoothVelocity, turnSmoothTime);
        
        
        //
        //
        //child.rotation = Quaternion.Euler(rotate);
        child.rotation = Quaternion.Euler(0,_yRotation,0);
        
        
        /*Vector3 rotate = new Vector3(0,Mathf.SmoothDampAngle(child.eulerAngles.y, targetAngleX, ref turnSmoothVelocity, turnSmoothTime),
            -Mathf.SmoothDampAngle(child.eulerAngles.y, targetAngleX * 0.5f, ref turnSmoothVelocity, turnSmoothTime));*/
        
    }
}
