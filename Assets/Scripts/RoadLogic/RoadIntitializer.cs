using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;

public class RoadIntitializer : MonoBehaviour
{
    [SerializeField] private SOPoolableObject _PoolableSO;
    [SerializeField] private int _RoadPlacementLimit = 20;
    [SerializeField] private float _RoadPlacementIteration = 57f;
    [SerializeField] private float _XRotation;

    private PoolableObject _PrefabRef;
    private float _CurrentRoadPosition;

    private void Awake()
    {
        _PrefabRef = _PoolableSO.PrefabRef;
        PoolManager.CreatePool(_PrefabRef, 40);
        for (int i = 0; i < _RoadPlacementLimit + 1; i++)
        {
            var currentRoad = PoolManager.GetNext(_PrefabRef, new Vector3(0f, 0f, _CurrentRoadPosition),
                Quaternion.Euler(_XRotation, 0f, 0f), true);
            _CurrentRoadPosition += _RoadPlacementIteration;
        }
    }
}