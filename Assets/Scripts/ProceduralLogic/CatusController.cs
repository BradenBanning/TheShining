using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatusController : MonoBehaviour
{
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
        var range = Random.Range(0, _CactusArray.Length);
        
        var count =  Mathf.Clamp(range - 10, 0, 2);

        for (int i = 0; i < count; i++)
        {
            Debug.Log(range % _CactusArray.Length);
            _CactusArray[range % _CactusArray.Length].gameObject.SetActive(true);
            range += _CactusArray.Length / 2;
        }
        
        
    }

    private void OnDisable()
    {
        for (int i = 0; i < _CactusArray.Length; i++)
        {
            if (_CactusArray[i].gameObject.activeInHierarchy == true)
            {
                _CactusArray[i].gameObject.SetActive(false);
            }
        }
    }
}