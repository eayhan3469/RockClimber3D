using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject _tapToPlayScreen;

    [SerializeField]
    private GameObject _gameOverScreen;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        GameManager.OnGameStart += OnGameStarted;
        GameManager.OnGameFail += OnGameFailed;
    }

    private void OnDisable()
    {
        GameManager.OnGameStart -= OnGameStarted;
        GameManager.OnGameFail -= OnGameFailed;
    }

    private void OnGameFailed()
    {
        _gameOverScreen.SetActive(true);
    }

    private void OnGameStarted()
    {
        _tapToPlayScreen.SetActive(false);
    }

    public void OnGameOverScreenClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
