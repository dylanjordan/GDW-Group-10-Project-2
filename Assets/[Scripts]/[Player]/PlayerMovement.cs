using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Info")]
    public Transform ground;
    public LayerMask groundMask;

    [Header("Movement Variables")]
    public float _speed = 5.0f;
    public float _gravity = -9.8f;
    public float _jumpHeight = 3.0f;
    public float disToGround = 0.4f;

    //internal privates
    private CharacterController _controller;
    private InputManager input;

    private Vector2 move;
    private Vector3 _playerVelo;

    private bool isGrounded;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        input = InputManager.Instance;
    }

    private void Update()
    {
        Grav();
        Movement();
        Jump();
    }

    //receives inputs from the InputManager.cs and apply them to the character controller
    public void Movement()
    {
        move = input.GetPlayerMovement();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        _controller.Move(movement * _speed * Time.deltaTime);
    }

    private void Grav()
    {
        isGrounded = Physics.CheckSphere(ground.position, disToGround, groundMask);

        if (isGrounded && _playerVelo.y < 0)
        {
            _playerVelo.y = -2f;
        }

        _playerVelo.y += _gravity * Time.deltaTime;
        _controller.Move(_playerVelo * Time.deltaTime);
    }
    public void Jump()
    {
       if (input.GetJumped())
        {
            _playerVelo.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }
}
