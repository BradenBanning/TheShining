using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatusController : MonoBehaviour
{
    private IsCactus[] _CactusArray;

    private void Awake()
    {
        _CactusArray = GetComponentsInChildren<IsCactus>();
    }
}
