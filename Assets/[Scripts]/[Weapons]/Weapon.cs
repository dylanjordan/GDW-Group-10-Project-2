using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("ADS Values")]
    public float _adsSpeed = 8f;
    public Vector3 aimPosition;

    private static Weapon _instance;
    //internal privates
    private Vector3 originalPosition;

    private InputManager input;
    public static Weapon Instance
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
    }
    private void Start()
    {
        input = InputManager.Instance;

        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        AimingDownSights();
    }

    //aiming down sites by checking input from InputManager.cs
    private void AimingDownSights()
    {
        if (input.GetADSIsTrigger())
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * _adsSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * _adsSpeed);
        }
    }

    public float GetAdsSpeed()
    {
        return _adsSpeed;
    }
}
