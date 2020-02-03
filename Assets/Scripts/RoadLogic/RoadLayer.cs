using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoadLayer : MonoBehaviour
{
    [SerializeField] private SOPoolableObject _PoolableSO;
    [SerializeField] float _StartPoint = 513 + 57;
    [SerializeField] private float _TimerLimit = 1.5f;
    [SerializeField] private float _XRotation;


    private float _Timer;
    private PoolableObject _PrefabRef;

    private void Awake()
    {
        _PrefabRef = _PoolableSO.PrefabRef;
    }

    private void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer < _TimerLimit) return;
        _Timer = 0f;
        var nextRoad = PoolManager.GetNext(_PrefabRef, new Vector3(0f, 0f, _StartPoint),
            Quaternion.Euler(_XRotation, 0f, 0f), true);
        nextRoad.transform.localPosition = new Vector3(0f, 0f, _StartPoint);
        nextRoad.transform.localRotation = Quaternion.Euler(_XRotation, 0f, 0f);
    }
}