using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawObstacle : Obstacle
{
    [SerializeField] private float _overriddenSpeed = 0f;

    private float _speed;
    private void Start()
    {
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        _speed = 1f / Mathf.Clamp(_overriddenSpeed, 0.1f, Mathf.Infinity);

        MoveLeftRight();

        if (_overriddenSpeed == 0f)
            _speed = GameParameters.Instance.SawObstacleSpeed;
        else
            _speed = 1f / Mathf.Clamp(_overriddenSpeed, 0.1f, Mathf.Infinity);
    }

    private void MoveLeftRight()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(2f, _speed).SetEase(Ease.Linear));
        sequence.Append(transform.DOMoveX(0f, _speed).SetEase(Ease.Linear));
        sequence.Append(transform.DOMoveX(-2f, _speed).SetEase(Ease.Linear));
        sequence.Append(transform.DOMoveX(0f, _speed).SetEase(Ease.Linear));
        sequence.SetLoops(-1, LoopType.Restart);
    }
}
