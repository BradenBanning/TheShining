using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoadLerp : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 1.5f;
    [SerializeField] float _MoveSpeedMultiplier = 0.05f;
    [SerializeField] private float _TimerLimit = 0.02f;

    private float _Timer;

    private void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer >= _TimerLimit)
        {
            _Timer = 0;
            var newPos = transform.position.z - (_MoveSpeed * _MoveSpeedMultiplier);
            transform.localPosition = new Vector3(0f, 0f, newPos);
            
        }
    }
}