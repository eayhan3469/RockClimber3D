using System;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [HideInInspector] public Rigidbody Rigidbody;
    [HideInInspector] public bool IsAvailable = true;
    public bool IsFinishStone;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (!IsAvailable)
            return;

        GameManager.OnAStoneClicked?.Invoke(this);
    }
}
