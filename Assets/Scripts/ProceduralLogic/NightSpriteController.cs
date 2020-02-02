using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSpriteController : MonoBehaviour
{
    [SerializeField] private SOFloat PhaseInteratorRef;
    [SerializeField] private SOTimer _GameTimerRef;
    [SerializeField] private Sprite[] _Sprites;
    private SpriteRenderer _SpriteRenderer;

    private void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _GameTimerRef.IsTimerRunning += PhaseHasChanged;
    }

    private void OnDisable()
    {
        _GameTimerRef.IsTimerRunning -= PhaseHasChanged;
    }

    private void PhaseHasChanged(bool val)
    {
        if (val == true) return;

        if (PhaseIsNight() == true)
        {
            _SpriteRenderer.sprite = _Sprites[1];
        }
        else
        {
            _SpriteRenderer.sprite = _Sprites[0];
        }
    }

    private bool PhaseIsNight()
    {
        return Mathf.RoundToInt(PhaseInteratorRef.Value) % 2 != 0;
    }
}