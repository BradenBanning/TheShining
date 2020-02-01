using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/CarLogic")]
public class SOCarLogic : ScriptableObject
{
    public SOCarLogic Ref { get; private set; }
    public CarTurn CarTurnRef { get; private set; }
    public CarLateralMovement CarMoveRef { get; private set; }
    
    public void CreateRunTimeObject(CarTurn val1, CarLateralMovement val2)
    {
        Ref = ScriptableObject.CreateInstance<SOCarLogic>();
        Ref.SetValue(val1 , val2);
    }

    public void SetValue(CarTurn val1, CarLateralMovement val2)
    {
        CarTurnRef = val1;
        CarMoveRef = val2;
    }

}
