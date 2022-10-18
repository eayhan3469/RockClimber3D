using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Stone[] Stones;

    public static Action OnGameStart;
    public static Action OnGameFinish;
    public static Action OnGameFail;
    public static Action<Stone> OnAStoneClicked;

    public bool GameHasStarted = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Stones = FindObjectsOfType<Stone>();
    }

    private void Update()
    {
        if (!GameHasStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnGameStart?.Invoke();
            }
        }
    }
}
