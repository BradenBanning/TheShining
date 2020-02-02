using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;

public class SwitchStatesInput : MonoBehaviour
{
    public Action SwitchStatesEvent = new Action(delegate {  });


    private void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            StatesSwitched();
        }
    }
    
    public void StatesSwitched()
    {
        SwitchStatesEvent.Invoke();
    }
}
