using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSetter : MonoBehaviour
{
    [SerializeField] private SOImageRef _ImageSO;
    private Image _Image;


    private void Awake()
    {
        _Image = GetComponent<Image>();
        _ImageSO.CreateRunTimeObject(_Image);
    }
}
