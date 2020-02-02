using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptables/TextBox")]
public class SOTextBoxBehaviour : ScriptableObject
{
    
    [SerializeField] private String[] _GoalText;

        
    private int _CurrentCharacter;

    public int ChaptersCompleted { get; private set; } = 0;
    public int TotalChapters => _GoalText.Length;


    public void Initialize()
    {
        _CurrentCharacter = 0;
        ChaptersCompleted = 0;
    }
    
        
    public void TestInput(char input)
    {
        if (input == _GoalText[ChaptersCompleted].ToUpper()[_CurrentCharacter])
        {
            _CurrentCharacter++;
            Debug.Log($"Hit! : Current Character -> {_CurrentCharacter} : GoalText Length -> {_GoalText[ChaptersCompleted].Length}");
            if (_CurrentCharacter >= _GoalText[ChaptersCompleted].Length)
            {
                CompletedChapter();
            }
        }
    }

    private void CompletedChapter()
    {
        ChaptersCompleted++;
        _CurrentCharacter = 0;
        Debug.Log("Chapter Completed: Congrats");

        if (ChaptersCompleted >= TotalChapters)
        {
            Debug.Log("Book Finished: Congratulations!");
        }
        
    }

}
