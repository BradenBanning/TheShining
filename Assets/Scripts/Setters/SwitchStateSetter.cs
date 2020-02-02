using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStateSetter : MonoBehaviour
{
    [SerializeField] private SOSwitchState _SwitchStateSO;
    private SwitchStatesInput _SwichStatesInput;

    private void Awake()
    {
        _SwichStatesInput = GetComponent<SwitchStatesInput>();
        _SwitchStateSO.CreateRunTimeObject(_SwichStatesInput);
    }
}
