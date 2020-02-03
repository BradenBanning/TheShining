using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameOverTracker : MonoBehaviour
{
    [SerializeField] private SOGameObjectRef _RoadChunksRef;
    [SerializeField] private SOGameOverEvent _GameOverEventRef;
    [SerializeField] private float _WarningPos = 9f;
    [SerializeField] private float _GameOverPos = 15f;
    private bool _IsInGameOverArea = false;
    private bool _PosBad = false;
    private bool _NegBad = false;


    private void Update()
    {
        if (_RoadChunksRef.Instance.Value.transform.position.x < -_GameOverPos ||
            _RoadChunksRef.Instance.Value.transform.position.x > _GameOverPos)
        {
            _GameOverEventRef.GameOverHappened.Invoke();
        }
        else if ((_RoadChunksRef.Instance.Value.transform.position.x < -_WarningPos && _IsInGameOverArea == false && _NegBad == false))

        {
            _NegBad = true;
            _IsInGameOverArea = true;
            _GameOverEventRef.InsideGameOverZone.Invoke(true);
        }
        else if (_RoadChunksRef.Instance.Value.transform.position.x > _WarningPos && _IsInGameOverArea == false && _PosBad == false)
        {
            _PosBad = true;
            _IsInGameOverArea = true;
            _GameOverEventRef.InsideGameOverZone.Invoke(true);
        }
        else if (_RoadChunksRef.Instance.Value.transform.position.x > -_WarningPos && _IsInGameOverArea == true &&
                 _NegBad == true)

        {
            _PosBad = false;
            _NegBad = false;
            _IsInGameOverArea = false;
            _GameOverEventRef.InsideGameOverZone.Invoke(false);
        }
        else if (_RoadChunksRef.Instance.Value.transform.position.x < _WarningPos && _IsInGameOverArea == true &&
                 _PosBad == true)
        {
            _PosBad = false;
            _NegBad = false;
            _IsInGameOverArea = false;
            _GameOverEventRef.InsideGameOverZone.Invoke(false);
        }
    }
}