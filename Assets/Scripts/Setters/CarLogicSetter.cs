using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLogicSetter : MonoBehaviour
{
    [SerializeField] private SOCarLogic _SOCarLogic;
    private CarTurn _CarTurn;
    private CarLateralMovement _CarMove;


    private void Awake()
    {
        _CarTurn = GetComponent<CarTurn>();
        _CarMove = GetComponent<CarLateralMovement>();
        _SOCarLogic.CreateRunTimeObject(_CarTurn, _CarMove);
    }
}
