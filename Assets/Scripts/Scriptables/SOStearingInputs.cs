using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/StearingRef")]
public class SOStearingInputs : ScriptableObject
{
    public SOStearingInputs Ref { get; private set; }
    public StearingInputs Value { get; private set; }

    public void CreateRunTimeObject(StearingInputs val)
    {
        Ref = ScriptableObject.CreateInstance<SOStearingInputs>();
        Ref.SetValue(val);
    }

    public void SetValue(StearingInputs val)
    {
        Value = val;
    }
}
