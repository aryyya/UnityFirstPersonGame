using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float horizontalSensitivity = 3.0f;
    public float verticalSensitivity = 3.0f;

    public float minimumVerticalAngle = -45.0f;
    public float maximumVerticalAngle = +45.0f;

    private float _rotationX = 0.0f;
    private float _rotationY = 0.0f;

    public enum RotationAxis
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseXAndY;

    void Start()
    {
        _rotationX = transform.localEulerAngles.x;
        _rotationY = transform.localEulerAngles.y;
}

    void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * verticalSensitivity;
        _rotationY += Input.GetAxis("Mouse X") * horizontalSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, minimumVerticalAngle, maximumVerticalAngle);
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY);
    }
}
