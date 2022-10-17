using System;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool IsAvailable = true;

    private void OnMouseDown()
    {
        if (!IsAvailable)
            return;

        GameManager.OnAStoneClicked?.Invoke(this);
    }
}
