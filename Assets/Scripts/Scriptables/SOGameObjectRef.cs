using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/GORef")]
public class SOGameObjectRef : ScriptableObject
{
    public SOGameObjectRef Instance { get; private set; }
    public GameObject Value { get; private set; }

    public void CreateRunTimeObject(GameObject val)
    {
        Instance = ScriptableObject.CreateInstance<SOGameObjectRef>();
        Instance.SetValue(val);
    }

    public void SetValue(GameObject val)
    {
        Value = val;
    }
}
