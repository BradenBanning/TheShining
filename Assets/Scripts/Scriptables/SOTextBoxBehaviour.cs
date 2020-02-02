using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOTextBoxBehaviour : MonoBehaviour
{
    
    [SerializeField] private String[] _GoalText;

        
    private int _CurrentCharacter;
    
    public int ChaptersCompleted { get; private set; }
    public int TotalChapters => _GoalText.Length; 
    


    public void TestInput(char input)
    {
        if (input == _GoalText[ChaptersCompleted][_CurrentCharacter])
        {
            _CurrentCharacter++;
            if (_CurrentCharacter >= _GoalText.Length)
            {
                CompletedChapter();
            }
        }
    }

    private void CompletedChapter()
    {
        ChaptersCompleted++;
        Debug.Log("Chapter Completed: Congrats");

        if (ChaptersCompleted >= TotalChapters + 1)
        {
            Debug.Log("Book Finished: Congratulations!");
        }
        
    }

}
