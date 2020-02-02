using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] _Sprites;
    private SpriteRenderer _SpriteRenderer;

    private void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        var spriteToSelect = Random.Range(0, _Sprites.Length);
        
        _SpriteRenderer.sprite = _Sprites[spriteToSelect];
    }
}
