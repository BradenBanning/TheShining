using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoadLerp : MonoBehaviour
{
    [SerializeField] private Vector3 _Velocity;

    private Rigidbody _RB;

    private float _Timer;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();
        
        _RB.velocity = _Velocity;
    }

}