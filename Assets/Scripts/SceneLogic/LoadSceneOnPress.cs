using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class LoadSceneOnPress : MonoBehaviour
{
    [SerializeField] private string _SceneName = "MaceoScene";

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadScene();
        }
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(_SceneName);
    }
}
