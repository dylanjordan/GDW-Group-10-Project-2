using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Mouse input;

    private Quaternion originRotation;

    public float _intensity;
    public float _smoothness;

    private void Start()
    {
        input = Mouse.Instance;

        originRotation = transform.localRotation;
    }
    private void Update()
    {
        UpdateSway();
    }

    //creating weapon sway from movement
    private void UpdateSway()
    {
        //getting mouse input from Mouse.cs
        float mouseX = input.GetMouseX();
        float mouseY = input.GetMouseY();

        //calculating target rotation
        Quaternion xtargetAdj = Quaternion.AngleAxis(-_intensity * mouseX, Vector3.up);
        Quaternion ytargetAdj = Quaternion.AngleAxis(_intensity * mouseY, Vector3.right);
        Quaternion targetRotation = originRotation * xtargetAdj * ytargetAdj;

        //rotating gun towards target rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * _smoothness);

    }
}
