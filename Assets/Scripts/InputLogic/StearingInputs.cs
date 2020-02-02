using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StearingInputs : MonoBehaviour
{
    [SerializeField] private SOStearingInputs _StearingInputsRef;

    public Action<int> StearingEvent = new Action<int>(delegate { });

    public void StearingSucceded()
    {
        if (_StearingInputsRef.Instance._PositiveXMovement >= _StearingInputsRef.Instance._NegativeXMovement)
        {
            StearingEvent.Invoke(1);
            Debug.Log("Pos");
        }
        else
        {
            StearingEvent.Invoke(-1);
            Debug.Log("!Pos");
        }
    }
}