using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/StearingRef")]
public class SOStearingInputs : ScriptableObject
{
    public SOStearingInputs Instance { get; private set; }
    public StearingInputs Value { get; private set; }
    
    public int _PositiveXMovement { get; private set; }
    public int _NegativeXMovement { get; private set; }

    public void CreateRunTimeObject(StearingInputs val)
    {
        Instance = ScriptableObject.CreateInstance<SOStearingInputs>();
        Instance.SetValue(val);
    }

    public void SetValue(StearingInputs val)
    {
        Value = val;
    }

    public void IncreasePositiveMovement()
    {
        _PositiveXMovement++;
    }

    public void IncreaseNegativeMovement()
    {
        _NegativeXMovement++;
    }

    public void ResetDirectionalMovement()
    {
        _PositiveXMovement = 0;
        _NegativeXMovement = 0;
    }
    
}
