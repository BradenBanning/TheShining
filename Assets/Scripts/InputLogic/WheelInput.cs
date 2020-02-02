using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(SphereCollider))]
public class WheelInput : MonoBehaviour
{
    [SerializeField] private SOStearingInputs _StearingInputsRef;
    [SerializeField] private Camera _Cam;
    [SerializeField] private float _InputGoal = 3f;

    private SphereCollider _WheelCollider;
    private float _InputRecieved;

    private void Awake()
    {
        _WheelCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) == false) return;
        _InputRecieved = 0f;
    }

    private void FixedUpdate()
    {
        var ray = _Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit) == false) return;
        if (hit.transform.GetComponent<SphereCollider>() != _WheelCollider || Input.GetMouseButton(0) == false) return;

        _InputRecieved += Time.fixedDeltaTime;

        if (_InputRecieved <= _InputGoal) return;

        _InputRecieved = 0f;
        _StearingInputsRef.Ref.Value.StearingSucceded();
    }
}