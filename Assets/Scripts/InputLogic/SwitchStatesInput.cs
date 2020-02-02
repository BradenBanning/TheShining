using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;

public class SwitchStatesInput : MonoBehaviour
{
    public Action SwitchStatesEvent = new Action(delegate {  });

    private int _IsInDriveState;


    private void Update()
    {
        if (Input.GetButtonDown("Switch") || (Input.mouseScrollDelta.y < 0 && (_IsInDriveState == 0 || _IsInDriveState % 2 == 0)) || (Input.mouseScrollDelta.y > 0 && (_IsInDriveState % 2 != 0)))
        {
            StatesSwitched();
            _IsInDriveState++;
        }
    }
    
    public void StatesSwitched()
    {
        SwitchStatesEvent.Invoke();
    }
}
