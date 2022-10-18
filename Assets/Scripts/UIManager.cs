using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _tapToPlayScreen;
    [SerializeField] private GameObject _finishScreen;
    [SerializeField] private GameObject _gameOverScreen;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        GameManager.OnGameStart += OnGameStarted;
        GameManager.OnGameFinish += OnGameFinished;
        GameManager.OnGameFail += OnGameFailed;
    }

    private void OnDisable()
    {
        GameManager.OnGameStart -= OnGameStarted;
        GameManager.OnGameFinish -= OnGameFinished;
        GameManager.OnGameFail -= OnGameFailed;
    }

    private void OnGameStarted()
    {
        _tapToPlayScreen.SetActive(false);
    }
    private void OnGameFinished()
    {
        _finishScreen.SetActive(true);
    }

    private void OnGameFailed()
    {
        _gameOverScreen.SetActive(true);
    }

    public void OnGameRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
