using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarLateralMovement : MonoBehaviour
{
    [Header("Scriptables")]
    [SerializeField] private SOGameObjectRef _RoadChunksRef;
    [SerializeField] private SOStearingInputs _StearingInputsRef;
    [SerializeField] private SOTimer _TimerRef;
    
    [SerializeField] private Vector3 _MoveAmount;

    private bool _IsTimerRunning = true;

    private float _CurrentPosition;
    
    private void OnEnable()
    {
        _TimerRef.IsTimerRunning += ChangeTimerStatus;
        _StearingInputsRef.Instance.Value.StearingEvent += ChangeMovementDirection;
    }
    
    
    private void OnDisable()
    {
        _TimerRef.IsTimerRunning -= ChangeTimerStatus;
        _StearingInputsRef.Instance.Value.StearingEvent -= ChangeMovementDirection;
    }

    private void ChangeMovementDirection(int direction)
    {
        _MoveAmount.x *= -1f * direction;
    }

    private void ChangeTimerStatus(bool status)
    {
        _IsTimerRunning = status;
    }

    private void Update()
    {
        if (_IsTimerRunning == true) return;
        
        _CurrentPosition += _MoveAmount.x;
        var yPos = _RoadChunksRef.Ref.Value.transform.position.y;
        var zPos = _RoadChunksRef.Ref.Value.transform.position.z;
        _RoadChunksRef.Ref.Value.transform.position = new Vector3(-_CurrentPosition, yPos, zPos);
        
        if(_MoveAmount.x > 0f || -_CurrentPosition < 0) return;
        
        ResetCarPosition();
        
    }

    public void ResetCarPosition()
    {
        _TimerRef.TryStartTimer();
        // ChangeMovementDirection();
    }
}