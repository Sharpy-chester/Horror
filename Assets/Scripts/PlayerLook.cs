using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    float xRot;
    [SerializeField] float mouseSensitivity;
    internal bool canLook = true;

    void Awake()
    {
        canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (canLook)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);
            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            transform.parent.Rotate(Vector3.up * mouseX);
        }
    }
}
