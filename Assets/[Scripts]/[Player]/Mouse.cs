using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    //mouse input variables
    public float mouseX;
    public float mouseY;

    //internal privates
    private static Mouse _instance;
    private InputManager input;
    private Transform _playerBody;
    private Vector2 mouseLook;

    private float _mouseSensitivity = 40.0f;
    private float xRotation = 0f;

    public static Mouse Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

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

        mouseX = mouseLook.x * _mouseSensitivity * Time.deltaTime;
        mouseY = mouseLook.y * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        _playerBody.Rotate(Vector2.up * mouseX);


    }

    public float GetMouseX()
    {
        return mouseX;
    }

    public float GetMouseY()
    {
        return mouseY;
    }
}
