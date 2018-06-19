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
        float deltaX = Input.GetAxis("Mouse Y") * verticalSensitivity;
        float deltaY = Input.GetAxis("Mouse X") * horizontalSensitivity;

        _rotationX -= deltaX;
        _rotationY += deltaY;

        _rotationX = Mathf.Clamp(_rotationX, minimumVerticalAngle, maximumVerticalAngle);

        transform.localEulerAngles = new Vector3(_rotationX, _rotationY);
    }
}
