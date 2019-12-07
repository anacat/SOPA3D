using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlMovement : MonoBehaviour
{

    public float movementSpeed = 2.0f;
    public float maxSpeed = 10.0f;
    public float rotationSpeed = 200.0f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion deviceRotation = DeviceRotation.Get();
        transform.rotation = deviceRotation;
    }
}
