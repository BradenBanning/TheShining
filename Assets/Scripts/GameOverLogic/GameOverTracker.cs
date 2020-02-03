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


    private void Update()
    {
        if (_RoadChunksRef.Instance.Value.transform.position.x < -_GameOverPos ||
            _RoadChunksRef.Instance.Value.transform.position.x > _GameOverPos)
        {
            _GameOverEventRef.GameOverHappened.Invoke();
        }
        else if (_RoadChunksRef.Instance.Value.transform.position.x < -_WarningPos ||
                 _RoadChunksRef.Instance.Value.transform.position.x > _WarningPos)
        {
            _GameOverEventRef.InsideGameOverZone.Invoke(true);
            Debug.Log("Turn Car!");
        }
    }
}