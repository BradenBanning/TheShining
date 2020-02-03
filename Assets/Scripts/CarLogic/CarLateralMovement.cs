using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarLateralMovement : MonoBehaviour
{
    [Header("Scriptables")] [SerializeField]
    private SOGameObjectRef _RoadChunksRef;

    [SerializeField] private SOStearingInputs _StearingInputsRef;
    [SerializeField] private SOTimer _TimerRef;
    [SerializeField] private SOSwitchState _SwitchStateRef;


    [SerializeField] private float _SpeedStateReducer = 0.25f;
    [SerializeField] private Vector3 _MoveAmount;

    private float _CurrentPosition;
    private float _SpeedMultiplier = 1f;

    private void OnEnable()
    {
        _StearingInputsRef.Instance.Value.StearingEvent += ChangeMovementDirection;
        _SwitchStateRef.Instance.Value.SwitchStatesEvent += StatesSwitched;
    }

    private void StatesSwitched()
    {
        if (_SwitchStateRef.Instance.Value.IsInDriveState % 2 == 0)
        {
            _SpeedMultiplier = _SpeedStateReducer;
        }
        else
        {
            _SpeedMultiplier = 1;
        }
    }


    private void OnDisable()
    {
        _StearingInputsRef.Instance.Value.StearingEvent -= ChangeMovementDirection;
        _SwitchStateRef.Instance.Value.SwitchStatesEvent -= StatesSwitched;
    }

    private void ChangeMovementDirection(int direction)
    {
        if ((_MoveAmount.x < 0 && direction < 0) || (_MoveAmount.x > 0 && direction > 0))
        {
            _MoveAmount.x *= -1f;
        }
    }


    private void Update()
    {
        _CurrentPosition += (_MoveAmount.x *_SpeedMultiplier);
        var yPos = _RoadChunksRef.Instance.Value.transform.position.y;
        var zPos = _RoadChunksRef.Instance.Value.transform.position.z;
        _RoadChunksRef.Instance.Value.transform.position = new Vector3(-_CurrentPosition, yPos, zPos);

        if (_MoveAmount.x > 0f || -_CurrentPosition < 0) return;

        ResetCarPosition();
    }

    public void ResetCarPosition()
    {
        _TimerRef.TryStartTimer();
    }
}