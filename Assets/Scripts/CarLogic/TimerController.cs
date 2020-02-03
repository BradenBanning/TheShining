using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimerController : MonoBehaviour
{
    [SerializeField] private SOTimer _TimerRef;
    [SerializeField] private float _TimerLimit = 1f;


    private void Awake()
    {
        _TimerRef.SetTimeLimit(_TimerLimit);
    }

    private void Update()
    {
        _TimerRef.ModifyValue(Time.deltaTime);
        if (_TimerRef.CheckIfTimerLimitReached() == false) return;
        _TimerRef.StopTimer();

    }

}