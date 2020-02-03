using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;

public class SwitchStatesInput : MonoBehaviour
{
    public Action SwitchStatesEvent = new Action(delegate {  });

    public int IsInDriveState { get; private set; }


    private void Update()
    {
        if (Input.GetButtonDown("Switch") || (Input.mouseScrollDelta.y < 0 && (IsInDriveState == 0 || IsInDriveState % 2 == 0)) || (Input.mouseScrollDelta.y > 0 && (IsInDriveState % 2 != 0)))
        {
            StatesSwitched();
            IsInDriveState++;
        }
    }
    
    public void StatesSwitched()
    {
        SwitchStatesEvent.Invoke();
    }
}
