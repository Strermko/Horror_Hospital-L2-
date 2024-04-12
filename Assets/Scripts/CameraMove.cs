using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 3f; // Adjust this to change the speed of camera rotation

    private Vector3 lastMousePosition;

    void Update()
    {
        MoveCamera();

        RotateCamera();
    }

    private void MoveCamera()
    {
        // Calculate movement direction based on user input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float upInput = Input.GetKey(KeyCode.E) ? 1f : 0f;
        float downInput = Input.GetKey(KeyCode.Q) ? -1f : 0f;
        Vector3 movementDirection = new Vector3(horizontalInput, upInput + downInput, verticalInput);

        // Normalize the direction to prevent faster diagonal movement
        if (movementDirection.magnitude > 1f)
        {
            movementDirection.Normalize();
        }

        // Move the camera based on the input
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    void RotateCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
            Cursor.visible = false;
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotateHorizontal = delta.x * rotationSpeed * Time.deltaTime;
            float rotateVertical = -delta.y * rotationSpeed * Time.deltaTime; // Invert vertical movement
            transform.Rotate(Vector3.up, rotateHorizontal, Space.World);
            transform.Rotate(transform.right, rotateVertical, Space.World); // Rotate along the camera's right vector
            lastMousePosition = Input.mousePosition;
        } else {
            Cursor.visible = true;
        }
    }
}
