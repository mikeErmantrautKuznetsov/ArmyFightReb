using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, ICameraController
{
    public Transform camTransform;
    public Transform pivot;
    public Transform Character;
    public Transform mTransform;

    public CameraConfigCharacter CameraConfigCharacter;
    public CameraConfig CameraConfig;
    public bool leftPivot;
    public float delta;

    public float mouseX;
    public float mouseY;
    public float smoothX;
    public float smoothY;
    public float smoothXVelocity;
    public float smoothYVelocity;
    public float lookAngle;
    public float titelAngle;


    public void cameraRotation()
    {
        FixedTick();
    }

    void FixedTick()
    {
        delta = Time.deltaTime;

        HandlePosition();
        HandleRotation();

        Vector3 targetPosition = Vector3.Lerp(mTransform.position, Character.position, 1);
        mTransform.position = targetPosition;
    }

    void HandlePosition()
    {
        float targetX = CameraConfig.normalX;
        float targetY = CameraConfig.normalY;
        float targetZ = CameraConfig.normalZ;

        if (CameraConfigCharacter.isAming)
        {
            targetX = CameraConfig.aimX;
            targetZ = CameraConfig.aimZ;
        }

        if(leftPivot)
        {
            targetX = -targetX;
        }

        Vector3 newPivotPosition = pivot.localPosition;
        newPivotPosition.x = targetX;
        newPivotPosition.y = targetY;

        Vector3 newCameraPosition = camTransform.localPosition;
        newCameraPosition.z = targetZ;

        float t = delta * CameraConfig.pivotSpeed;
        pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPosition, t);
        camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, newCameraPosition, t);
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (CameraConfig.turnSmooht > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, CameraConfig.turnSmooht);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, CameraConfig.turnSmooht);
        }
        else
        {
            smoothX = mouseX; 
            smoothY = mouseY;
        }

        lookAngle += smoothX * CameraConfig.YRotationSpeed;
        Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
        mTransform.rotation = targetRot;

        titelAngle -= smoothY * CameraConfig.YRotationSpeed;
        titelAngle = Mathf.Clamp(titelAngle, CameraConfig.minAngel, CameraConfig.maxAngel);
        pivot.localRotation = Quaternion.Euler(titelAngle,0,0);
    }

    //[SerializeField]
    //private Transform playerBody;

    //private float mouseSensivety = 500f;

    //private float xRotation;

    //[System.Obsolete]
    //public void cameraRotation()
    //{
    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensivety * Time.deltaTime;
    //    float mouseY = Input.GetAxis("Mouse Y") * mouseSensivety * Time.deltaTime;

    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -25f, 25f);

    //    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    //    playerBody.Rotate(Vector3.up * mouseX);
    //}
}
