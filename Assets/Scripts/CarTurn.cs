using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarTurn : MonoBehaviour
{
    private float _Timer;
    private float _TimerLimit;

    private void Update()
    {
        _Timer += Time.deltaTime;

        if (_Timer >= _TimerLimit)
        {
            
        }
    }
}
