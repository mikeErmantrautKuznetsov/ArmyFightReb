using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private ICameraController controller;

    private void Awake()
    {
        controller = GetComponent<ICameraController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        controller.cameraRotation();
    }
}
