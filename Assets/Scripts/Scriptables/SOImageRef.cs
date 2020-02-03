using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptables/ImageRef")]
public class SOImageRef : ScriptableObject
{
    public SOImageRef Ref { get; private set; }
    public Image Value { get; private set; }
    
    public void CreateRunTimeObject(Image val)
    {
        Ref = ScriptableObject.CreateInstance<SOImageRef>();
        Ref.SetValue(val);
    }

    public void SetValue(Image val)
    {
        Value = val;
    }
}
