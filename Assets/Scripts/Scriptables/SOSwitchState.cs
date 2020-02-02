using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/SwitchState")]
public class SOSwitchState : ScriptableObject
{
    public SOSwitchState Instance { get; private set; }
    public SwitchStatesInput Value { get; private set; }

    public void CreateRunTimeObject(SwitchStatesInput val)
    {
        Instance = ScriptableObject.CreateInstance<SOSwitchState>();
        Instance.SetValue(val);
    }

    public void SetValue(SwitchStatesInput val)
    {
        Value = val;
    }
}
