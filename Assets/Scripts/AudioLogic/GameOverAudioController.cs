using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameOverAudioController : MonoBehaviour
{
    [SerializeField] private SOGameOverEvent _GameOverEventRef;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _GameOverClip;
    [SerializeField] private AudioClip _ReturnToRoadClip;
    [SerializeField] private AudioClip _DummyClip;

    private void OnEnable()
    {
        _GameOverEventRef.InsideGameOverZone += PlayReturnToRoad;
        _GameOverEventRef.GameOverHappened += PlayDeth;
    }

    private void OnDisable()
    {
        _GameOverEventRef.InsideGameOverZone -= PlayReturnToRoad;
        _GameOverEventRef.GameOverHappened -= PlayDeth;
    }

    private void PlayDeth()
    {
        if (_AudioSource.clip == _GameOverClip) return;
        _AudioSource.Stop();
        _AudioSource.loop = false;
        _AudioSource.clip = _GameOverClip;
        _AudioSource.Play();
    }


    private void PlayReturnToRoad(bool val)
    {
        if (val == true)
        {
            if (_AudioSource.clip == _ReturnToRoadClip) return;

            _AudioSource.Stop();
            _AudioSource.loop = true;
            _AudioSource.clip = _ReturnToRoadClip;
            _AudioSource.Play();
        }
        
        else if (val == false)
        {
            _AudioSource.Stop();
            _AudioSource.clip = _DummyClip;
        }
    }
}