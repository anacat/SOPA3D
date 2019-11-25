using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyEffect : MonoBehaviour
{
    public float waterLevel;
    public float floatHeight;
    public float bounceDamp;
    public Vector3 buoyancyCenterOffset;

    private float _forceFactor;
    private Vector3 _actionPoint;
    private Vector3 _upLift;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _actionPoint = transform.position + transform.TransformDirection(buoyancyCenterOffset);
        _forceFactor = 1f - ((_actionPoint.y - waterLevel) / floatHeight);

        if (_forceFactor > 0f)
        {
            _upLift = -Physics.gravity * (_forceFactor - _rigidBody.velocity.y * bounceDamp);
            _rigidBody.AddForceAtPosition(_upLift, _actionPoint);
        }
    }
}
