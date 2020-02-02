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
    }
}
