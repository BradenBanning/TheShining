using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMoveObject : MonoBehaviour
{
    
    [SerializeField] private SOGameOverEvent _GameOverEventRef;
    
    [SerializeField] private float _MoveSpeed = 1.5f;
    [SerializeField] float _MoveSpeedMultiplier = 0.5f;
    [SerializeField] private float _TimerLimit = 0.02f;

    private float _Timer;
    private bool _GameOver = false;

    private void OnEnable()
    {
        _GameOverEventRef.GameOverHappened += GameOverHappened;
    }

    private void GameOverHappened()
    {
        _GameOver = true;
    }

    private void Update()
    {
        if (_GameOver == false) return;
        
        _Timer += Time.deltaTime;
        if (_Timer >= _TimerLimit)
        {
            var xPos = transform.position.x;
            var yPos = transform.position.y;
            _Timer = 0;
            var newPos = transform.position.z - (_MoveSpeed * _MoveSpeedMultiplier);
            transform.localPosition = new Vector3(xPos, yPos, newPos);
        }

        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSecondsRealtime(3f);
        Application.Quit();
    }
}