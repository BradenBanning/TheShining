using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLerp : MonoBehaviour
{
    [Header("Timer")] private float _Timer;
    [SerializeField] private float _TimerGoal = 10f;

    [Header("Lerp")] private float _LerpFraction;
    [SerializeField] private float _LerpSpeed = 0.01f;

    [Header("Position")] [SerializeField] private float _PositionIncrement = -57f;

    private float _LastPostionPoint;
    public float CurrentPositionGoal => _LastPostionPoint += _PositionIncrement;

    private void Awake()
    {
        _LastPostionPoint = transform.position.z;
    }

    private void Update()
    {
        _Timer += Time.deltaTime;
        // if (_Timer >= _TimerGoal)
        {
            // _Timer = 0f;
            _LerpFraction += (_LerpSpeed *Time.deltaTime);
            _LerpFraction += _Timer;
            
            
            
            var zPos = Mathf.Lerp(_LastPostionPoint, (CurrentPositionGoal), _LerpFraction);
            
            
            
            Debug.Log($"LastPoint -> {_LastPostionPoint} P Fraction -> {_LerpFraction* Time.deltaTime} zPos ->  {zPos}" );

            transform.position = new Vector3(0f, 0f, zPos);
        }
        // if (transform.position.z <= CurrentPositionGoal)
        {
            // _LastPostionPoint += _PositionIncrement;
        }
    }
}