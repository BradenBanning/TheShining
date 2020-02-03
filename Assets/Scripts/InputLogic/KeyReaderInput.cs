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
                else if (vKey.ToString() == KeyCode.Comma.ToString())
                {
                    char inputChar = ',';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Exclaim.ToString())
                {
                    char inputChar = '!';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.DoubleQuote.ToString())
                {
                    char inputChar = '"';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha1.ToString() || vKey.ToString() == KeyCode.Keypad1.ToString())
                {
                    char inputChar = '1';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha2.ToString() || vKey.ToString() == KeyCode.Keypad2.ToString())
                {
                    char inputChar = '2';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha3.ToString() || vKey.ToString() == KeyCode.Keypad3.ToString())
                {
                    char inputChar = '3';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha4.ToString() || vKey.ToString() == KeyCode.Keypad4.ToString())
                {
                    char inputChar = '4';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha5.ToString() || vKey.ToString() == KeyCode.Keypad5.ToString())
                {
                    char inputChar = '5';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha6.ToString() || vKey.ToString() == KeyCode.Keypad6.ToString())
                {
                    char inputChar = '6';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha7.ToString() || vKey.ToString() == KeyCode.Keypad7.ToString())
                {
                    char inputChar = '7';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha8.ToString() || vKey.ToString() == KeyCode.Keypad8.ToString())
                {
                    char inputChar = '8';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha9.ToString() || vKey.ToString() == KeyCode.Keypad9.ToString())
                {
                    char inputChar = '9';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Alpha0.ToString() || vKey.ToString() == KeyCode.Keypad0.ToString())
                {
                    char inputChar = '0';
                    _TextBoxRef.TestInput(inputChar);
                }

                else if (vKey.ToString() == KeyCode.Minus.ToString() ||
                         vKey.ToString() == KeyCode.KeypadMinus.ToString())
                {
                    char inputChar = '-';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Semicolon.ToString())
                {
                    char inputChar = ';';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Colon.ToString())
                {
                    char inputChar = ':';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.Question.ToString())
                {
                    char inputChar = '?';
                    _TextBoxRef.TestInput(inputChar);
                }
                
                else if (vKey.ToString() == KeyCode.LeftBracket.ToString())
                {
                    char inputChar = '(';
                    _TextBoxRef.TestInput(inputChar);
                }
                else if (vKey.ToString() == KeyCode.RightBracket.ToString())
                {
                    char inputChar = ')';
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