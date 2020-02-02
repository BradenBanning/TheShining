using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatueController : MonoBehaviour
{
    [SerializeField] private SOTimer _GameTimerRef;

    private int PhaseInterator = 1;

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

        if (PhaseInterator % 2 != 0)
        {
            if (Random.Range(0, 49) <= 0)
            {
                var position = Random.Range(0, _StatueArray.Length);

                _StatueArray[position].gameObject.SetActive(true);
            }
        }
    }

    private void PhaseHasChanged(bool obj)
    {
        PhaseInterator++;
        DisableAllStatues();
    }

    private void OnDisable()
    {
        DisableAllStatues();
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
}