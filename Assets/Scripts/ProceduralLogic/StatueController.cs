using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatueController : MonoBehaviour
{
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
        if (Random.Range(0, 49) <= 0)
        {
            var position = Random.Range(0, _StatueArray.Length);

            _StatueArray[position].gameObject.SetActive(true);
        }
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