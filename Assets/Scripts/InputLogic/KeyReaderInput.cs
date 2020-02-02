using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReaderInput : MonoBehaviour
{
    [SerializeField] private SOTextBoxBehaviour _TextBoxRef;

    private void Awake()
    {
        _TextBoxRef.Initialize();
    }

    private void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                if (vKey.ToString() == KeyCode.Space.ToString())
                {
                    char inputChar = ' ';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Period.ToString())
                {
                    char inputChar = '.';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if ( vKey.ToString() == KeyCode.Comma.ToString())
                {
                    char inputChar = ',';
                    _TextBoxRef.TestInput(inputChar);
                    
                }
                else
                {
                    char inputChar = vKey.ToString().ToCharArray()[0];
                    _TextBoxRef.TestInput(inputChar);
                }
            }
        }
    }
}