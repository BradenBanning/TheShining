using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;

public class RoadIntitializer : MonoBehaviour
{
    [SerializeField] private PoolableObject _PrefabRef;
    [SerializeField] private int _RoadPlacementLimit = 10;
    [SerializeField] private float _RoadPlacementIteration = 57f;
    private float _CurrentRoadPosition;

    private void Awake()
    {
        PoolManager.CreatePool(_PrefabRef, 12);
        for (int i = 0; i < _RoadPlacementLimit + 1; i++)
        {
            var currentRoad = PoolManager.GetNext(_PrefabRef);
            currentRoad.transform.position = new Vector3(0f, 0f, _CurrentRoadPosition);
            currentRoad.gameObject.SetActive(true);
            _CurrentRoadPosition += _RoadPlacementIteration;
        }
    }
}