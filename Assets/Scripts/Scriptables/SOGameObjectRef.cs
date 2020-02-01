using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/GORef")]
public class SOGameObjectRef : ScriptableObject
{
    public SOGameObjectRef Ref { get; private set; }
    public GameObject Value { get; private set; }
    
    public void CreateRunTimeObject(GameObject val)
    {
        Ref = ScriptableObject.CreateInstance<SOGameObjectRef>();
        Ref.SetValue(val);
    }

    public void SetValue(GameObject val)
    {
        Value = val;
    }
}
