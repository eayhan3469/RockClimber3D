using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject _tapToPlay;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStart += OnGameStarted;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        _tapToPlay.SetActive(false);
    }
}