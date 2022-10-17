using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [HideInInspector] public Rigidbody Rigidbody;
    [HideInInspector] public Rigidbody DefaultConnectedRigidbody;

    private FixedJoint _fixedJoint;

    private void Start()
    {
        _fixedJoint = GetComponent<FixedJoint>();
        Rigidbody = GetComponent<Rigidbody>();
        DefaultConnectedRigidbody = _fixedJoint.connectedBody;
    }

    public void UpdateConnectedBody(Rigidbody rb)
    {
        _fixedJoint.connectedBody = rb;
    }

    public void SetDefaultConnectedBody()
    {
        _fixedJoint.connectedBody = DefaultConnectedRigidbody;
    }
}
