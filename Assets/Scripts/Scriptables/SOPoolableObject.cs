using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/PoolableObject")]
public class SOPoolableObject : ScriptableObject
{
    public PoolableObject PrefabRef;
}
