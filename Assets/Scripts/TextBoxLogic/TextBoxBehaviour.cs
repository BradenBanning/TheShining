using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxBehaviour : MonoBehaviour
{
    public Texture2D textureToDisplay;

    void OnGUI()
    {
        GUI.Label(new Rect(550, 600, 500, 500), "Hello World!");
        GUI.Label(new Rect(100, 400, textureToDisplay.width, textureToDisplay.height), textureToDisplay);
    }
}




//     private string _textName = "text";
//
//     public string TextName
//     {
//         get { return _textName; }
//         set
//         {
//             _textName = value;
//             // RaisePropertyChanged(nameof(TextName));
//         }
//     }


// <StackPanel>
// <TextBlock Text = "{Binding TextName}" FontSize = "30"></TextBlock>
// <TextBox Text = "{Binding TextName, 
// UpdateSourceTrigger = PropertyChanged}">
// </TextBox>
// </StackPanel>
