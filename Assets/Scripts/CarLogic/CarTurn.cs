using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarTurn : MonoBehaviour
{
    [SerializeField] private SOStearingInputs _StearingInputsRef;
    [SerializeField] private SOImageRef _DashBoardRef;
    [SerializeField] private SOGameObjectRef _RoadChunksRef;
    [SerializeField] private Vector3 _RotationAmount;
    [SerializeField] private float _TurnMaximum = 1.8f;
    [SerializeField] private float _TimerLimit;


    private float _Timer;
    private float _TurnDirection = 1f;

    private void OnEnable()
    {
        _StearingInputsRef.Ref.Value.StearingEvent += ChangeTurnDirection;
    }

    private void OnDisable()
    {
        _StearingInputsRef.Ref.Value.StearingEvent -= ChangeTurnDirection;
    }


    private void Update()
    {
        RotateCar();
    }

    private void RotateCar()
    {
        _Timer += Time.deltaTime;
        if (_Timer <= _TimerLimit) return;
        if (_TurnDirection == 1f && _DashBoardRef.Ref.Value.transform.rotation.y * Mathf.Rad2Deg >= _TurnMaximum) return;

        _DashBoardRef.Ref.Value.transform.Rotate(_TurnDirection * _RotationAmount);
        _RoadChunksRef.Ref.Value.transform.Rotate((-_TurnDirection * _RotationAmount )/ 2f);

        if (_TurnDirection == 1f || _DashBoardRef.Ref.Value.transform.rotation.y > 0f) return;
        ChangeTurnDirection();
        
        Debug.Log("Goal Direction!");
        ResetCarRotation();
    }

    private void ChangeTurnDirection()
    {
        Debug.Log("Change Direction!");
        _TurnDirection *= -1;
    }


    private void ResetCarRotation()
    {
        Debug.Log("Reset");
        _Timer = 0f;

        if (_RoadChunksRef)
            _DashBoardRef.Ref.Value.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        _RoadChunksRef.Ref.Value.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
}