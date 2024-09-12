using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTank : MonoBehaviour
{
    private float speedRotate = 200f;
    public Transform tankPlayer;
    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * speedRotate * Time.deltaTime;

        xRotation -= horizontal;
        xRotation = Mathf.Clamp(xRotation, xRotation, xRotation);

        transform.localRotation = Quaternion.Euler(0f, -xRotation, 0f);
        tankPlayer.Rotate(Vector3.up * horizontal * Time.deltaTime);
    }
}
