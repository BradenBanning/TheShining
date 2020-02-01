using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StearingInputSetter : MonoBehaviour
{

    [SerializeField] private SOStearingInputs _StrearingInputSO;
    private StearingInputs _StearingInput;

    private void Awake()
    {
        _StearingInput = GetComponent<StearingInputs>();
        _StrearingInputSO.CreateRunTimeObject(_StearingInput);
    }
}
