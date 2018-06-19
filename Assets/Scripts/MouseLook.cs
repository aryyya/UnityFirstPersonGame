using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float horizontalSensitivity = 3.0f;
    public float verticalSensitivity = 3.0f;

    public float minimumVerticalAngle = -60.0f;
    public float maximumVerticalAngle = +60.0f;

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
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }

        Cursor.visible = false;

        _rotationX = transform.localEulerAngles.x;
        _rotationY = transform.localEulerAngles.y;
    }

    void Update()
    {
        if (axes == RotationAxis.MouseXAndY)
        {
            SetRotationXAndY();
        }
        else if (axes == RotationAxis.MouseX)
        {
            SetRotationX();
        }
        else if (axes == RotationAxis.MouseY)
        {
            SetRotationY();
        }

        transform.localEulerAngles = new Vector3(_rotationX, _rotationY);
    }


    private void SetRotationXAndY()
    {
        SetRotationX();
        SetRotationY();
    }

    private void SetRotationX()
    {
        float deltaX = Input.GetAxis("Mouse Y") * verticalSensitivity;
        _rotationX -= deltaX;
        _rotationX = Mathf.Clamp(_rotationX, minimumVerticalAngle, maximumVerticalAngle);
    }

    private void SetRotationY()
    {
        float deltaY = Input.GetAxis("Mouse X") * horizontalSensitivity;
        _rotationY += deltaY;
    }
}
