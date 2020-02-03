using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/GameOverEvent")]
public class SOGameOverEvent : ScriptableObject
{
    public Action GameOverHappened = delegate { };
    public Action<bool> InsideGameOverZone = delegate(bool b) {  };
    
}