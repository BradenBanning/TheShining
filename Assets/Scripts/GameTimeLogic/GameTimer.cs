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

    public int CurrentPhase { get; private set; } = 0;

    private void Awake()
    {
        _GameTimerRef.SetTimeLimit(_GamePhaseTimeLimit);
        _GameTimerRef.TryStartTimer();
        _PhaseIteratorRef.SetValue(1f);
    }

    private void Update()
    {
        _GameTimerRef.ModifyValue(Time.deltaTime);
        if (_GameTimerRef.CheckIfTimerLimitReached())
        {
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
        Debug.Log("Limit Reached");
        if (val == false)
        {
            _PhaseIteratorRef.ModifyValue(1f);
        }

        _GameTimerRef.TryStartTimer();
        CurrentPhase++;

        if (CurrentPhase > _NumberOfPhasesPerGame)
        {
            _GameWinEventRef.GameWinHappened.Invoke();
        }
    }
}