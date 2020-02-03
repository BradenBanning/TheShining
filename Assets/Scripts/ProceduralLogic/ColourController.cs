using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    [SerializeField] private SOFloat PhaseInteratorRef;
    [SerializeField] private SOTimer _GameTimerRef;
    [SerializeField] private SOGameOverEvent _GameOverEventRef;
    [SerializeField] private Color[] _Colors;
    [Header("Game Over")] [SerializeField] private bool _HasGameOverColor = true;
    [SerializeField] private int _GameOverColorPos = 2;
    private SpriteRenderer _SpriteRenderer;

    private void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _GameTimerRef.IsTimerRunning += PhaseHasChanged;
        _GameOverEventRef.GameOverHappened += GameOverHappened;

        if (Mathf.RoundToInt(PhaseInteratorRef.Value) == 1)
        {
            _SpriteRenderer.color = _Colors[0];
        }
        
        else if (PhaseIsNight() == true)
        {
            _SpriteRenderer.color = _Colors[1];
        }
        else
        {
            _SpriteRenderer.color = _Colors[0];
        }

    }

    private void GameOverHappened()
    {
        if (_HasGameOverColor == true)
        {
            _SpriteRenderer.color = _Colors[_GameOverColorPos];
        }
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
            _SpriteRenderer.color = _Colors[1];
        }
        else
        {
            _SpriteRenderer.color = _Colors[0];
        }
    }

    private bool PhaseIsNight()
    {
        return Mathf.RoundToInt(PhaseInteratorRef.Value) % 2 != 0;
    }
}