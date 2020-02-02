using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CactusController : MonoBehaviour
{
    [SerializeField] private SOTimer _GameTimerRef;

    [SerializeField] private SOFloat PhaseInteratorRef;

    private IsCactus[] _CactusArray;

    private void Awake()
    {
        _CactusArray = GetComponentsInChildren<IsCactus>();
        for (int i = 0; i < _CactusArray.Length; i++)
        {
            _CactusArray[i].gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _GameTimerRef.IsTimerRunning += PhaseHasChanged;

        if (PhaseIsNight() == false)
        {
            if (Random.Range(0, 4) <= 0)
            {
                var range = Random.Range(0, _CactusArray.Length);

                var count = Mathf.Clamp(range - 10, 0, 2);

                for (int i = 0; i < count; i++)
                {
                    // Debug.Log(range % _CactusArray.Length);
                    _CactusArray[range % _CactusArray.Length].gameObject.SetActive(true);
                    range += _CactusArray.Length / 2;
                }
            }
        }
    }

    private void OnDisable()
    {
        _GameTimerRef.IsTimerRunning -= PhaseHasChanged;
        DisableAllCacti();
    }

    private void DisableAllCacti()
    {
        for (int i = 0; i < _CactusArray.Length; i++)
        {
            if (_CactusArray[i].gameObject.activeInHierarchy == true)
            {
                _CactusArray[i].gameObject.SetActive(false);
            }
        }
    }

    private void PhaseHasChanged(bool val)
    {
        if (PhaseIsNight() == true && val == false)
        {
            DisableAllCacti();
        }
    }

    private bool PhaseIsNight()
    {
        return Mathf.RoundToInt(PhaseInteratorRef.Value) % 2 != 0;
    }
}