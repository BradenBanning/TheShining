using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchStates : MonoBehaviour
{
    [SerializeField] private SOSwitchState _SwitchStateInputRef;
    [SerializeField] private float _MoveSpeed = 0.05f;
    [SerializeField] private float _UpperDestination = 500f;
    [SerializeField] private float _LowerDestination = 1f;
    [SerializeField] private float _TimerLimit = 0.01f;
    private bool _InPhoneState = false;
    private int _MoveDirection = -1;
    private bool _IsMoving = false;
    private float _Timer;

    private void OnEnable()
    {
        _SwitchStateInputRef.Instance.Value.SwitchStatesEvent += SwitchPlayState;
    }

    private void OnDisable()
    {
        _SwitchStateInputRef.Instance.Value.SwitchStatesEvent -= SwitchPlayState;
    }

    private void Update()
    {
        if (_IsMoving == false) return;
        // _Timer += Time.deltaTime;
        // if (_Timer >= _TimerLimit)
        {
            _Timer = 0f;
            MoveToNextState();
        }
    }

    private void MoveToNextState()
    {
        var newPos = transform.localPosition.y + (_MoveSpeed * _MoveDirection);
        var xPos = transform.localPosition.x;
        var zPos = transform.localPosition.z;
        transform.localPosition = new Vector3(xPos, newPos, zPos);

        if (_MoveDirection == 1 && transform.localPosition.y >= _UpperDestination)
        {
            newPos = _UpperDestination;
            transform.localPosition = new Vector3(xPos, newPos, zPos);
            _IsMoving = false;
        }
        else if (_MoveDirection == -1 && transform.localPosition.y <= _LowerDestination)
        {
            newPos = _LowerDestination;
            transform.localPosition = new Vector3(xPos, newPos, zPos);
            _IsMoving = false;
        }
    }

    private void SwitchPlayState()
    {
        CheckCurrentState();
        _MoveDirection *= -1;
        EnableMoveToNextState();
    }

    private void CheckCurrentState()
    {
        if (_InPhoneState == false)
        {
            _InPhoneState = true;
        }
        else
        {
            _InPhoneState = false;
        }
    }

    private void EnableMoveToNextState()
    {
        _IsMoving = true;
    }
}