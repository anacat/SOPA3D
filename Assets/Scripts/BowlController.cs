﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlController : MonoBehaviour
{
    public GameObject liquidParent;
    public GameObject liquidMesh;

    public float sloshSpeed = 60;
    public float rotateSpeed = 15;

    private int difference = 25;

    private void Update()
    {
        Slosh();

        liquidParent.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void Slosh()
    {
        //inverse cup rotation
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        //rotate to
        Vector3 finalRotation = Quaternion
            .RotateTowards(liquidParent.transform.localRotation, inverseRotation, sloshSpeed * Time.deltaTime).eulerAngles;

        //clamp
        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        //set
        liquidParent.transform.localEulerAngles = finalRotation;
    }

    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0f;

        if (value > 180)
        {
            //clamp
            returnValue = Mathf.Clamp(value, 360 - difference, 360);
        }
        else
        {
            //clamp
            returnValue = Mathf.Clamp(value, 0, difference);
        }

        return returnValue;
    }
}
