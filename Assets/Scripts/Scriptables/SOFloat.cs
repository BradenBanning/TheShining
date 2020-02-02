using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Variables/Float", fileName = "FloatRef_")]
public class SOFloat : ScriptableObject
{
    public float Value { get; private set; }

    public void SetValue(float val)
    {
        Value = val;
    }

    public void ModifyValue(float val)
    {
        Value += val;
    }
    
}
