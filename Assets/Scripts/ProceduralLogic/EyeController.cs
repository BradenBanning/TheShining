﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    [SerializeField] private SOTimer _GameTimerRef;

    [SerializeField] private SOFloat PhaseInteratorRef;

    private IsEye[] _EyeArray;

    [SerializeField] private float _DefaultSpawnTime = 1.5f;

    [SerializeField] private float _StartSpawnTime = 60;
    private float _TimeBetweenEyeSpawn;

    private void Awake()
    {
        _EyeArray = GetComponentsInChildren<IsEye>();
        for (int i = 0; i < _EyeArray.Length; i++)
        {
            _EyeArray[i].gameObject.SetActive(false);
        }

        _TimeBetweenEyeSpawn = _StartSpawnTime;
    }

    private void OnEnable()
    {
        _GameTimerRef.IsTimerRunning += PhaseHasChanged;
    }

    private void OnDisable()
    {
        _GameTimerRef.IsTimerRunning -= PhaseHasChanged;
        DisableAllEyes();
    }

    private IEnumerator EyeEnabler()
    {
        foreach (var eye in _EyeArray)
        {
            _TimeBetweenEyeSpawn += _DefaultSpawnTime;
            yield return new WaitForSeconds(_TimeBetweenEyeSpawn);
            if (_TimeBetweenEyeSpawn >= 60f)
            {
                _TimeBetweenEyeSpawn = _DefaultSpawnTime;
            }

            eye.gameObject.SetActive(true);
        }
    }


    private void DisableAllEyes()
    {
        StopAllCoroutines();
        for (int i = 0; i < _EyeArray.Length; i++)
        {
            if (_EyeArray[i].gameObject.activeInHierarchy == true)
            {
                _EyeArray[i].gameObject.SetActive(false);
            }
        }
    }

    private void PhaseHasChanged(bool val)
    {
        if (val == true) return;
        if (PhaseIsNight() == false)
        {
            DisableAllEyes();
        }
        else if (PhaseIsNight() == true)
        {
            _TimeBetweenEyeSpawn = _StartSpawnTime;
            StartCoroutine(EyeEnabler());
        }
    }

    private bool PhaseIsNight()
    {
        return Mathf.RoundToInt(PhaseInteratorRef.Value) % 2 != 0;
    }
}