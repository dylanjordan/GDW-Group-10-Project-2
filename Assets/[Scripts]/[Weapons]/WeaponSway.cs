using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Values")]
    public float _intensity;
    public float _smoothness;
    public float _yBobMultiplier;

    //interal privates
    private Mouse input;
    private InputManager manager;
    private Quaternion originRotation;

    private void Start()
    {
        input = Mouse.Instance;
        manager = InputManager.Instance;

        originRotation = transform.localRotation;
    }
    private void Update()
    {
        if (!manager.GetADSIsTrigger())
        {
            UpdateSway();
        }
    }

    //creating weapon sway from movement
    private void UpdateSway()
    {
        //getting mouse input from Mouse.cs
        float mouseX = input.GetMouseX();
        float mouseY = input.GetMouseY();

        //calculating target rotation
        Quaternion xtargetAdj = Quaternion.AngleAxis(-_intensity * mouseX, Vector3.up);
        Quaternion ytargetAdj = Quaternion.AngleAxis(_intensity * mouseY * _yBobMultiplier, Vector3.right);
        Quaternion targetRotation = originRotation * xtargetAdj * ytargetAdj;

        //rotating gun towards target rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * _smoothness);

    }
}
