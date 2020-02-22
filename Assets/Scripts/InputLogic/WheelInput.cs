using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;

[RequireComponent(typeof(SphereCollider))]
public class WheelInput : MonoBehaviour
{
    [SerializeField] private SOStearingInputs _StearingInputsRef;
    [SerializeField] private Camera _Cam;
    [SerializeField] private float _InputGoal = 3f;

    private Vector3 _LastInputVector;


    private SphereCollider _WheelCollider;
    private float _InputRecieved;
    private bool _LeftKeyHit;
    private bool _KeyInputRecieved;
    private bool _RightKeyHit;
    private int _MouseValue = 1;
    private bool _MouseHit;


    private void Awake()
    {
        _WheelCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            KeyHitSetter(0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            KeyHitSetter(1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _MouseHit = true;
            _MouseValue *= -1;
        }

        if (Input.GetMouseButtonUp(0) == false) return;
        _InputRecieved = 0f;
    }

    private void KeyHitSetter(int val)
    {
        _KeyInputRecieved = true;
        _MouseValue *= -1;
        if (val < 1)
        {
            _LeftKeyHit = true;
            return;
        }

        _RightKeyHit = true;
    }

    private void FixedUpdate()
    {
        var ray = _Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit) == false) return;
        if ((hit.transform.GetComponent<SphereCollider>() != _WheelCollider ||
             _MouseHit == false) && _KeyInputRecieved == false) return;


        if (_LeftKeyHit == true || _MouseValue == -1)
        {
            _StearingInputsRef.Instance.IncreasePositiveMovement();
        }
        else if (_RightKeyHit == true || _MouseValue == 1)
        {
            _StearingInputsRef.Instance.IncreaseNegativeMovement();
        }

        _StearingInputsRef.Instance.Value.StearingSucceded();
        _StearingInputsRef.Instance.ResetDirectionalMovement();
        _LeftKeyHit = false;
        _RightKeyHit = false;
        _KeyInputRecieved = false;
        _MouseHit = false;
    }
}