using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelf : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.1f);

    private Vector2 lastMousePosition;
    private Vector2 newAngle = Vector2.zero;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            newAngle = transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;

            transform.localEulerAngles = newAngle;
            lastMousePosition = Input.mousePosition;
        }
    }
}
