using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Variables/Timer", fileName = "TimerRef_")]
public class SOTimer : SOFloat
{
    [SerializeField] private int _ScriptsAffectingTimer = 2;
     
    public Action<bool> IsTimerRunning = delegate {  };
    
    
    private float _TimerLimit;
    private int _ScriptsReadyForTimerChange;
    private int _Count;

    public void SetTimeLimit(float val)
    {
        _TimerLimit = val;
    }

    public bool CheckIfTimerLimitReached()
    {
        return (Value >= _TimerLimit == true);
    }

    public void StopTimer()
    {
        IsTimerRunning.Invoke(false);
    }
    

    public void TryStartTimer()
    {
        _Count++;
        Debug.Log(_Count);
        if (AllScriptsAreReady() == true) return;
        ResetTimer();
        IsTimerRunning.Invoke(true);
    }

    private bool AllScriptsAreReady()
    {
        _ScriptsReadyForTimerChange++;
        if (_ScriptsReadyForTimerChange < _ScriptsAffectingTimer) return true;

        _ScriptsReadyForTimerChange = 0;
        return false;
    }

    private void ResetTimer()
    {
        SetValue(0f);
    }
}
