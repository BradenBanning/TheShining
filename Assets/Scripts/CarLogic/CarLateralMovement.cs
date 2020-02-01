using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarLateralMovement : MonoBehaviour
{
    [SerializeField] private SOGameObjectRef _RoadChunksRef;
    [SerializeField] private Vector3 _MoveAmount;
    [SerializeField] private float _TimerLimit;
    
    

    private float _CurrentPosition;


    private float _Timer;

    private void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer >= _TimerLimit)
        {
            _CurrentPosition += _MoveAmount.x;
            var yPos = _RoadChunksRef.Ref.Value.transform.position.y;
            var zPos = _RoadChunksRef.Ref.Value.transform.position.z;
            _RoadChunksRef.Ref.Value.transform.position = new Vector3(-_CurrentPosition, yPos, zPos);
        }
    }

    public void ResetCarPosition()
    {
        _Timer = 0f;
        _RoadChunksRef.Ref.Value.transform.position = new Vector3(0f, 0f, 0f);
    }
}