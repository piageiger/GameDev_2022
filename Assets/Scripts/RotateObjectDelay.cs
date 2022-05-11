using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectDelay : MonoBehaviour
{
    public float angle = 90f;
    public float time = 2f;
    public string axis = "x";

    private Vector3 rotateAxis;
    // Use this for initialization
    void Start()
    {
        if (axis == "x")
        {
            rotateAxis = Vector3.right;
        }
        if (axis == "y")
        {
            rotateAxis = Vector3.up;
        }
        if (axis == "z")
        {
            rotateAxis = Vector3.forward;
        }
        StartCoroutine(RotateObject(angle, rotateAxis, time));
    }

    IEnumerator RotateObject(float angle, Vector3 axis, float inTime)
    {
        // calculate rotation speed
        float rotationSpeed = angle / inTime;

        while (true)
        {
            // save starting rotation position
            Quaternion startRotation = transform.rotation;

            float deltaAngle = 0;

            // rotate until reaching angle
            while (deltaAngle < angle)
            {
                deltaAngle += rotationSpeed * Time.deltaTime;
                deltaAngle = Mathf.Min(deltaAngle, angle);

                transform.rotation = startRotation * Quaternion.AngleAxis(deltaAngle, axis);

                yield return null;
            }

            // delay here
            yield return new WaitForSeconds(time);
        }
    }
}