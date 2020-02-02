using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/SwitchState")]
public class SOSwitchState : ScriptableObject
{
    public SOSwitchState Ref { get; private set; }
    public SwitchStatesInput Value { get; private set; }

    public void CreateRunTimeObject(SwitchStatesInput val)
    {
        Ref = ScriptableObject.CreateInstance<SOSwitchState>();
        Ref.SetValue(val);
    }

    public void SetValue(SwitchStatesInput val)
    {
        Value = val;
    }
}
