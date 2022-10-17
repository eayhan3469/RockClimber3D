using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action OnGameStart;
    public Action OnGameFinish;

    public bool GameHasStarted = false;

    protected override void Awake()
    {
        base.Awake();
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
