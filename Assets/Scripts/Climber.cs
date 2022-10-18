using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Climber : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Grabber[] _grabbers; //Right now left hand and right hand, could be added another parts.

    private Stone _grabbedStone;
    private Grabber _selectedGrabber;
    private Rigidbody[] _rigidbodies;

    private void Awake()
    {
        _rigidbody.isKinematic = true;
    }

    private void Start()
    {
        GameManager.OnGameStart += OnGameStarted;
        GameManager.OnAStoneClicked += OnStoneClicked;

        _rigidbodies = GetComponentsInChildren<Rigidbody>();
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

            foreach (var grabber in _grabbers)
            {
                if (Vector3.Distance(grabber.transform.position, stone.transform.position) < GameParameters.Instance.MinGrabDistance && _selectedGrabber == null && _grabbedStone == null)
                {
                    _selectedGrabber = grabber;
                    _grabbedStone = stone;
                    GrabToStone();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _grabbers[0].Rigidbody.AddForce(Vector3.up * 5000f);
        }
    }

    private void OnStoneClicked(Stone stone)
    {
        if (_selectedGrabber != null)
        {
            _selectedGrabber.SetDefaultConnectedBody();
            _selectedGrabber = null;
        }

        foreach (var rb in _rigidbodies)
        {
            rb.angularDrag = 0f;
            rb.drag = 0f;
        }

        _grabbedStone = null;

        var direction = (stone.transform.position - _rigidbody.transform.position).normalized;
        _rigidbody.AddForce(direction * GameParameters.Instance.ClimberJumpForce);
    }

    private void GrabToStone()
    {
        _grabbedStone.IsAvailable = false;
        _selectedGrabber.transform.DOMove(_grabbedStone.transform.position, 1f).OnComplete(() => _selectedGrabber.UpdateConnectedBody(_grabbedStone.Rigidbody));

        DOVirtual.DelayedCall(1f, () =>
        {
            foreach (var rb in _rigidbodies)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.angularDrag = 100f;
                rb.drag = 5f;
            }
        });

        if (_grabbedStone.IsFinishStone)
            GameManager.OnGameFinish?.Invoke();
    }

    private void OnGameStarted()
    {
        _rigidbody.isKinematic = false;
    }
}
