﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlMovement : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public float rotationSpeed = 200.0f;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * movementSpeed); 

    }
}
