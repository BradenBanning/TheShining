using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptables/TextBox")]
public class SOTextBoxBehaviour : ScriptableObject
{
    [SerializeField] private String[] _GoalText;
    [SerializeField] private string _WinStateMent = "You Win!!!!";


    public int CurrentCharacter { get; private set; }
    public int ChaptersCompleted { get; private set; } = 0;
    public int TotalChapters => _GoalText.Length;


    public void Initialize()
    {
        CurrentCharacter = 0;
        ChaptersCompleted = 0;
    }


    public void TestInput(char input)
    {
        if (ChaptersCompleted >= TotalChapters) return;
        if (input == _GoalText[ChaptersCompleted].ToUpper()[CurrentCharacter])
        {
            CurrentCharacter++;
            Debug.Log(
                $"Hit! : Current Character -> {CurrentCharacter} : GoalText Length -> {_GoalText[ChaptersCompleted].Length}");
            if (CurrentCharacter >= _GoalText[ChaptersCompleted].Length)
            {
                CompletedChapter();
            }
        }
    }

    private void CompletedChapter()
    {
        CurrentCharacter = 0;
        Debug.Log("Chapter Completed: Congrats");
            ChaptersCompleted++;

        if (ChaptersCompleted >= TotalChapters)
        {
            Debug.Log("Book Finished: Congratulations!");
        }
    }

    public string GetGoalText()
    {
        if (ChaptersCompleted >= TotalChapters) return _WinStateMent;
        return _GoalText[ChaptersCompleted];
    }
}