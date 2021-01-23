using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour 
{
    public Transform playerCameraTransform;

    public float mouseXSpeed;
    public float mouseYSpeed;

    public float rotYLimit = 80f;

    private float rotX = 0;
    private float rotY = 0;

    private void Update() {
        rotX += Input.GetAxisRaw("Mouse X") * mouseXSpeed;
        transform.rotation = Quaternion.Euler(0, rotX, 0);

        rotY -= Input.GetAxisRaw("Mouse Y") * mouseYSpeed;
        rotY = Mathf.Clamp(rotY, -rotYLimit, rotYLimit);
        playerCameraTransform.rotation = Quaternion.Euler(rotY, rotX, 0);
    }
}
