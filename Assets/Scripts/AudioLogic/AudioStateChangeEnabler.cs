using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStateChangeEnabler : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;

    [SerializeField] private SOSwitchState _SwitchStateRef;

    private void OnEnable()
    {
        _SwitchStateRef.Instance.Value.SwitchStatesEvent += StatesSwitched;
    }

    private void StatesSwitched()
    {
        if (_SwitchStateRef.Instance.Value.IsInDriveState % 2 == 0)
        {
            _AudioSource.Play();
        }
        else
        {
            _AudioSource.Stop();
        }
    }
}
