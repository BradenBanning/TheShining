using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/GameWinEvent")]
public class SOGameWinEvent : ScriptableObject
{
    public Action GameWinHappened = delegate {  };

}
