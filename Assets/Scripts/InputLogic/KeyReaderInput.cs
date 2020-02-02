using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReaderInput : MonoBehaviour
{
    private void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                //your code here
            }
        }
    }
}