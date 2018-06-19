using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;

    void Start()
    {
    }

    void Update()
    {
        Sprint();

        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(deltaX, 0.0f, deltaY);
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2.0f;
        }
    }
}
