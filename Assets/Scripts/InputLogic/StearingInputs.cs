using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StearingInputs : MonoBehaviour
{
    public Action StearingEvent = new Action(delegate {  });

    public void StearingSucceded()
    {
        StearingEvent.Invoke();
    }
    
    
}
