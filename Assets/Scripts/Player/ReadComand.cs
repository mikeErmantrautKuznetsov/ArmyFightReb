using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ReadComand : MonoBehaviour, IControlleble
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private CameraConfigCharacter cameraConfigCharacter;
    [SerializeField]
    private Vector3 rotationDirection;
    [SerializeField]
    private Vector3 moveDirection;

    private float speedPlayer = 10f;
    private Vector3 velocity;
    private float gravity = -18.81f;
    private float jumpPlayer = 3f;

    [SerializeField]
    private Transform groundCheck;
    private float distanceGround = 0.4f;
    [SerializeField]
    private LayerMask groundMask;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void MoveController()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.forward * moveY + cameraTransform.right * moveX;
        characterController.Move(move * speedPlayer * Time.deltaTime);

        Vector3 moveCamera = cameraTransform.forward * moveY;
        moveCamera += cameraTransform.right * moveX;
        moveCamera.Normalize();
        moveDirection = moveCamera;
        rotationDirection = cameraTransform.forward;
    }

    public void RotationPerson()
    {
        if (!cameraConfigCharacter.isAming)
        {
            rotationDirection = moveDirection;
        }

        Vector3 targetDir = rotationDirection;
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
        {
            targetDir = transform.forward;
        }

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, 1);
        transform.rotation = targetRot;
    }

    public void GraviteController()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, distanceGround, groundMask);

        if (isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    public void JumpController()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpPlayer * -2 * gravity);

            characterController.Move(velocity * Time.deltaTime);
        }
    }

}
