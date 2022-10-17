using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Climber : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Rigidbody[] _grabberRigidbodies; //Right now left hand and right hand, could be added another parts.

    private Stone _grabbedStone;
    private Rigidbody _selectedGrabber;

    private void Awake()
    {
        _rigidbody.isKinematic = true;
    }

    private void Start()
    {
        GameManager.OnGameStart += OnGameStarted;
        GameManager.OnAStoneClicked += OnStoneClicked;
    }


    private void OnDestroy()
    {
        GameManager.OnGameStart -= OnGameStarted;
        GameManager.OnAStoneClicked -= OnStoneClicked;
    }

    private void Update()
    {
        foreach (var stone in GameManager.Instance.Stones)
        {
            if (!stone.IsAvailable)
                continue;

            foreach (var grabber in _grabberRigidbodies)
                if (Vector3.Distance(grabber.transform.position, stone.transform.position) < 1.5f)
                    GrabToStone(grabber, stone);
        }

        if (_selectedGrabber != null && _grabbedStone != null)
            _selectedGrabber.transform.position = _grabbedStone.transform.position;
    }

    private void OnStoneClicked(Stone stone)
    {
        foreach (var grabber in _grabberRigidbodies)
            grabber.isKinematic = false;

        _grabbedStone = null;
        _selectedGrabber = null;

        var direction = (stone.transform.position - _rigidbody.transform.position).normalized;
        _rigidbody.AddForce(direction * GameParameters.Instance.ClimberJumpForce);
    }

    private void GrabToStone(Rigidbody grabber, Stone stone)
    {
        _grabbedStone = stone;
        _selectedGrabber = grabber;

        stone.IsAvailable = false;
        grabber.isKinematic = true;
        Debug.Log("grabbed");
    }

    private void OnGameStarted()
    {
        _rigidbody.isKinematic = false;
    }
}
