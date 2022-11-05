using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Utility : MonoBehaviour
{
    public static GameObject playerRef;

    private void Awake()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
}
