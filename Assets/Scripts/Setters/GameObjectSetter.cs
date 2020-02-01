using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSetter : MonoBehaviour
{
    [SerializeField] private SOGameObjectRef _GameObjectSO;
    private GameObject _GameObject;


    private void Awake()
    {
        _GameObject = gameObject;
        _GameObjectSO.CreateRunTimeObject(_GameObject);
    }
}
