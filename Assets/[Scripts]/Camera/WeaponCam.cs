using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCam : MonoBehaviour
{
    [Header("FOV Values")]
    public float _adsFOV = 40f;
    public float _defaultFOV = 60f;

    public Camera myCam;
    //internal privates
    private InputManager input;
    private Weapon stats;

    private float initalFOV;

    private void Start()
    {
        input = InputManager.Instance;
        stats = Weapon.Instance;

        myCam = this.GetComponent<Camera>();
        initalFOV = myCam.fieldOfView;
    }

    private void Update()
    {
        FieldOfViewChanger();
    }

    //gets input value from InputManager.cs and changes field of view accordingly
    private void FieldOfViewChanger()
    {
        float _adsSpeed = stats.GetAdsSpeed();
        if (input.GetADSIsTrigger())
        {
            myCam.fieldOfView = Mathf.Lerp(myCam.fieldOfView, _adsFOV, Time.deltaTime * _adsSpeed);
        }
        else
        {
            myCam.fieldOfView = Mathf.Lerp(myCam.fieldOfView, _defaultFOV, Time.deltaTime * _adsSpeed);
        }
    }
}
