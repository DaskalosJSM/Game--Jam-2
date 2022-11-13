using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Wallrunning")]
    public WallRunning wallrun;
    public float wallrunningCap;
    public bool wallrunning = false;

    [Header("Camera")]
    public float rotation;
    public Transform target;


    [Header("GameObjects")]

    public Animator anim;
    [SerializeField] CharacterController _controller;
    public float walkingspeed;

    [Header("player")]

    public bool CanDoubleJump;
    public int Jumpcount;
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerSprint;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float wallrunrotationSpeed;
    [SerializeField] Camera _followCamera;
    [SerializeField] Vector3 _playerVelocity;
    public bool _groundedPlayer;
    [SerializeField] float _jumpHeight = 1.0f;
    public float _gravityValue = -9.81f;
    public bool playerIsAiming;

    private void Start()
    {
        wallrun = GetComponent<WallRunning>();
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        rotation = -30f;
        _playerSpeed = walkingspeed;
        _groundedPlayer = _controller.isGrounded;
        if (Input.GetKeyDown(KeyCode.Mouse1)) playerIsAiming = true;
        if (Input.GetKeyUp(KeyCode.Mouse1)) playerIsAiming = false;
        anim.SetBool("Movement", false);
        anim.SetBool("Run", false);
        anim.SetBool("IsAiming", false);
        anim.SetBool("Dublejump", false);
        anim.SetBool("Wallrun", false);


        Movement();

        if (_groundedPlayer)
        {
            wallrunningCap = 1;
            Jumpcount = 0;
            anim.SetBool("Wallrun", false);
            anim.SetBool("Grounded", true);
        }
        if (Input.GetKey(KeyCode.Q)) Run();
        if (Input.GetKeyDown("space") && Jumpcount < 2 && CanDoubleJump) DoubleJump();
        if (Input.GetButton("Jump") && _groundedPlayer) Jump();



    }

    void Run()
    {
        _playerSpeed = _playerSpeed * _playerSprint;
        anim.SetBool("Run", true);
    }
    void Jump()
    {
        _playerVelocity.y = 0f;
        _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        anim.SetBool("Grounded", false);

    }
    void DoubleJump()
    {
        anim.SetBool("Dublejump", true);
        _playerVelocity.y = 0f;
        _playerVelocity.y += Mathf.Sqrt(_jumpHeight * 2 * -3.0f * _gravityValue);
        Jumpcount++;
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        if (playerIsAiming)
        {
            // Quaternion desiredRotation = Quaternion.LookRotation(_followCamera.transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, _rotationSpeed * Time.deltaTime);
        }

        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        if (movementDirection != Vector3.zero)
        {
            anim.SetBool("Movement", true);
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
            if (wallrunning == true)
            {
                anim.SetBool("Wallrun", true);
                anim.SetBool("Dublejump", false);
                if (wallrun.wallLeft)
                {
                    Jumpcount = 0;
                    wallrunningCap--;
                    desiredRotation = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, rotation);
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, wallrunrotationSpeed * Time.deltaTime);
                }
                if (wallrun.wallRight)
                {
                    Jumpcount = 0;
                    Debug.Log(rotation);
                    if (rotation < 0) rotation = -rotation;
                    wallrunningCap--;
                    desiredRotation = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, rotation);
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, wallrunrotationSpeed * Time.deltaTime);
                }

            }


        }
        _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
    
}