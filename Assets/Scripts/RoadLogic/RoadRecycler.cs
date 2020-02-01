using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoadRecycler : MonoBehaviour
{
    [SerializeField] float _EndPoint = -57f;
    [SerializeField] float _StartPoint = 513 + 57;

    [SerializeField] private PoolableObject _PrefabRef;
    
    private PoolableObject _PoolableObjectRef;

    private void Awake()
    {
        _PoolableObjectRef = GetComponent<PoolableObject>();
    }

    private void Update()
    {
        if (transform.position.z <= _EndPoint)
        {
            _PoolableObjectRef.StartDisbler();
            var nextRoad = PoolManager.GetNext(_PrefabRef);
            nextRoad.transform.position = new Vector3(0f,0f,_StartPoint);
            nextRoad.gameObject.SetActive(true);
        }
        
    }
}
