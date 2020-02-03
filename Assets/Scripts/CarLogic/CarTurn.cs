using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarTurn : MonoBehaviour
{
    [Header("Scriptables")]
    [SerializeField] private SOStearingInputs _StearingInputsRef;
    [SerializeField] private SOImageRef _DashBoardRef;
    [SerializeField] private SOGameObjectRef _RoadChunksRef;
    [SerializeField] private SOTimer _TimerRef;
    
    [SerializeField] private Vector3 _RotationAmount;
    [SerializeField] private float _TurnMaximum = 1.8f;
    
    private float _TurnDirection = 1f;
    private bool _IsTimerRunning = true;

    private void OnEnable()
    {
        _StearingInputsRef.Instance.Value.StearingEvent += ChangeTurnDirection;
        _TimerRef.IsTimerRunning += ChangeTimerStatus;
    }


    private void OnDisable()
    {
        _StearingInputsRef.Instance.Value.StearingEvent -= ChangeTurnDirection;
    }


    private void Update()
    {
        RotateCar();
    }
    
    private void ChangeTimerStatus(bool status)
    {
        _IsTimerRunning = status;
    }

    private void RotateCar()
    {
        if (_IsTimerRunning == true) return;
        if (_TurnDirection == 1f &&
            _DashBoardRef.Ref.Value.transform.rotation.y * Mathf.Rad2Deg >= _TurnMaximum) return;

        _DashBoardRef.Ref.Value.transform.Rotate(_TurnDirection * _RotationAmount);
        _RoadChunksRef.Instance.Value.transform.Rotate((-_TurnDirection * _RotationAmount));

        if (_TurnDirection == 1f || (_DashBoardRef.Ref.Value.transform.rotation.y > 0f && _RoadChunksRef.Instance.Value.transform.rotation.y > 0f)) return;

        ResetCarRotation();
    }

    private void ChangeTurnDirection(int direction)
    {
        _TurnDirection *= -1;
    }


    private void ResetCarRotation()
    {
        _TimerRef.TryStartTimer();
        // ChangeTurnDirection();
    }
}