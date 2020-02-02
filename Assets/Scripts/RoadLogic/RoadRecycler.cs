using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoadRecycler : MonoBehaviour
{
    [SerializeField] float _EndPoint = -57f;

    private void Update()
    {
        if (transform.localPosition.z <= _EndPoint)
        {
            gameObject.SetActive(false);
        }
    }
}
