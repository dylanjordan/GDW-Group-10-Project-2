using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private InputManager input;
    private Transform _playerBody;
    private Vector2 mouseLook;

    private float _mouseSensitivity = 100.0f;
    private float xRotation = 0f;

    private void Awake()
    {
        _playerBody = transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        input = InputManager.Instance;
    }
    private void Update()
    {
        Look();
    }
    private void Look()
    {
        mouseLook = input.GetMouseMovement();

        float mouseX = mouseLook.x * _mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        _playerBody.Rotate(Vector2.up * mouseX);


    }
}
