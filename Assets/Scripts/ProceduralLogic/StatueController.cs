using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatueController : MonoBehaviour
{
    [SerializeField] private SOTimer _GameTimerRef;

    [SerializeField] private SOFloat PhaseInteratorRef;

    private IsStatue[] _StatueArray;

    private void Awake()
    {
        _StatueArray = GetComponentsInChildren<IsStatue>();
        for (int i = 0; i < _StatueArray.Length; i++)
        {
            _StatueArray[i].gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _GameTimerRef.IsTimerRunning += PhaseHasChanged;

        if (PhaseIsNight() == false)
        {
            if (Random.Range(0, 49) <= 0)
            {
                var position = Random.Range(0, _StatueArray.Length);

                _StatueArray[position].gameObject.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        _GameTimerRef.IsTimerRunning -= PhaseHasChanged;
        DisableAllStatues();
    }

    private void PhaseHasChanged(bool val)
    {
        if (PhaseIsNight() == true && val == false)
        {
            DisableAllStatues();
        }
    }


    private void DisableAllStatues()
    {
        for (int i = 0; i < _StatueArray.Length; i++)
        {
            if (_StatueArray[i].gameObject.activeInHierarchy == true)
            {
                _StatueArray[i].gameObject.SetActive(false);
            }
        }
    }

    private bool PhaseIsNight()
    {
        return Mathf.RoundToInt(PhaseInteratorRef.Value) % 2 != 0;
    }
}