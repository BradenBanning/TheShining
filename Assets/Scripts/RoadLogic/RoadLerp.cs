using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoadLerp : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 1.5f;
    [SerializeField] float _MoveSpeedMultiplier = 0.05f;

    private void Update()
    {
        var newPos = transform.position.z - (_MoveSpeed * _MoveSpeedMultiplier);
        transform.localPosition = new Vector3(0f,0f, newPos);
    }
}