using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TextBoxBehaviour : MonoBehaviour
{
    [SerializeField] private SOTextBoxBehaviour _TextBoxRef;

    [SerializeField] private TextMeshProUGUI _CurrentChapterDisplay;

    [SerializeField] private TextMeshProUGUI _TypingDisplay;


    private void Update()
    {
        _CurrentChapterDisplay.text = _TextBoxRef.GetGoalText();
        if (_TextBoxRef.CurrentCharacter > 0)
        {
            string currentTypingText = "";
            for (int i = 0; i < _TextBoxRef.CurrentCharacter ; i++)
            {
               currentTypingText = currentTypingText.Insert(currentTypingText.Length, _TextBoxRef.GetGoalText()[i].ToString());
            }
            Debug.Log(currentTypingText);

            _TypingDisplay.text = currentTypingText;
        }

        else
        {
            _TypingDisplay.text = "";
        }
    }
}