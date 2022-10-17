using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Climber : Singleton<Climber>
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Rigidbody _leftHandBody;
    [SerializeField] private Rigidbody _rightHandBody;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody.isKinematic = true;
    }

    private void Start()
    {
        GameManager.Instance.OnGameStart += OnGameStarted;
    }

    protected override void OnDestroy()
    {
        GameManager.Instance.OnGameStart -= OnGameStarted;
    }

    void Update()
    {


    }

    public void ForceAtPosition(Vector3 position)
    {
        var direction = (position - _rigidbody.transform.position).normalized;

        _rigidbody.AddForce(direction * GameParameters.Instance.ClimberJumpForce);
    }

    private void OnGameStarted()
    {
        _rigidbody.isKinematic = false;
    }
}
