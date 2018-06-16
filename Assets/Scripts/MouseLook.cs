using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float horizontalSensitivity = 3.0f;
    public float verticalSensitivity = 3.0f;

    public enum RotationAxis
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseXAndY;

    void Start()
    {
    }

    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            float horizontalTransform = Input.GetAxis("Mouse X") * horizontalSensitivity;
            transform.Rotate(0.0f, horizontalTransform, 0.0f);
        }
        else if (axes == RotationAxis.MouseY)
        {
            float verticalTransform = Input.GetAxis("Mouse Y") * verticalSensitivity;
            transform.Rotate(verticalTransform, 0.0f, 0.0f);
        }
        else
        {
            float horizontalTransform = Input.GetAxis("Mouse X") * horizontalSensitivity;
            float verticalTransform = Input.GetAxis("Mouse Y") * verticalSensitivity;
            transform.Rotate(-verticalTransform, horizontalTransform, 0.0f);
        }
    }
}
