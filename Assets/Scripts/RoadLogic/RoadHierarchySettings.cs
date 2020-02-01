using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHierarchySettings : MonoBehaviour
{
    [SerializeField] private SOGameObjectRef _RoadChunksRef;

    private void Awake()
    {
        gameObject.transform.SetParent(_RoadChunksRef.Ref.Value.transform);
    }
}
