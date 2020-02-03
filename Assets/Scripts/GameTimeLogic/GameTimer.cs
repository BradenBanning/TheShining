using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private SOTimer _GameTimerRef;

    [SerializeField] private SOGameWinEvent _GameWinEventRef;

    [SerializeField] private SOFloat _PhaseIteratorRef;

    [SerializeField] private float _GamePhaseTimeLimit = 480f;

    [SerializeField] private int _NumberOfPhasesPerGame = 60;
    
    private bool _TimerRunning = true;

    public int CurrentPhase { get; private set; } = 0;

    private void Awake()
    {
        _PhaseIteratorRef.SetValue(1f);
        _GameTimerRef.SetTimeLimit(_GamePhaseTimeLimit);
        _GameTimerRef.TryStartTimer();
    }

    private void Update()
    {
        if(_TimerRunning == false) return;

        
        _GameTimerRef.ModifyValue(Time.deltaTime);
        if (_GameTimerRef.CheckIfTimerLimitReached())
        {
            _TimerRunning = false;
            _GameTimerRef.StopTimer();
        }
    }

    private void OnEnable()
    {
        _GameTimerRef.IsTimerRunning += TimerReachedLimit;
    }

    private void OnDisable()
    {
        _GameTimerRef.IsTimerRunning -= TimerReachedLimit;
    }

    private void TimerReachedLimit(bool val)
    {
        if (val == false)
        {
            _PhaseIteratorRef.ModifyValue(1f);
        }

        _GameTimerRef.TryStartTimer();
        
        CurrentPhase++;
        _TimerRunning = true;

        if (CurrentPhase > _NumberOfPhasesPerGame)
        {
            _GameWinEventRef.GameWinHappened.Invoke();
        }
    }
}