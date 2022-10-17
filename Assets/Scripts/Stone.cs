using System;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private void OnMouseDown()
    {
        Climber.Instance.ForceAtPosition(transform.position);
    }
}
