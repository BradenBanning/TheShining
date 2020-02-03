using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip[] _Songs;
    [SerializeField] private AudioClip _TrackChangeAudio;
    [SerializeField] private AudioClip _DummyTrack;
    [SerializeField] private Image _ButtonImage;
    [SerializeField] private Sprite[] _ButtonArray;

    private int TrackPos = -1;


    private void Awake()
    {
        _AudioSource.clip = _DummyTrack;
        
        // _AudioSource.Play();
        // StartCoroutine(WaitForClipToEnd(_TrackChangeAudio.length));
    }

    private void OnEnable()
    {
        StartCoroutine(WaitForClipToEnd(0.5f));
        _ButtonImage.sprite = _ButtonArray[0];
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        _ButtonImage.sprite = _ButtonArray[1];
    }

    private IEnumerator WaitForClipToEnd(float trackLength)
    {
        yield return new WaitForSecondsRealtime(trackLength);

        _AudioSource.Stop();
        if (_AudioSource.clip == _TrackChangeAudio)
        {
            TrackPos++;
            if (TrackPos > _Songs.Length)
            {
                TrackPos = 0;
            }
            _AudioSource.clip = _Songs[TrackPos];
        }
        else
        {
            _AudioSource.clip = _TrackChangeAudio;
        }

        _AudioSource.Play();
        StartCoroutine(WaitForClipToEnd(_AudioSource.clip.length));
    }
}