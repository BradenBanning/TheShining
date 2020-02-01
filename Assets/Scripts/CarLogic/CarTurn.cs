using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarTurn : MonoBehaviour
{
    [SerializeField] private SOImageRef _DashBoardRef;
    [SerializeField] private SOGameObjectRef _RoadChunksRef;
    [SerializeField] private Vector3 _RotationAmount;
    [SerializeField] private float _TurnMaximum = 1.8f;
    [SerializeField] private float _TimerLimit;


    private float _Timer;


    private void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer <= _TimerLimit || _DashBoardRef.Ref.Value.transform.rotation.y * Mathf.Rad2Deg >= _TurnMaximum) return;

        _DashBoardRef.Ref.Value.transform.Rotate(_RotationAmount);
        _RoadChunksRef.Ref.Value.transform.Rotate(-_RotationAmount / 2f);
    }

    public void ResetCarRotation()
    {
        _Timer = 0f;
        _DashBoardRef.Ref.Value.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        _RoadChunksRef.Ref.Value.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
}