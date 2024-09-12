using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveRaed : MonoBehaviour, ITankMove
{
    [SerializeField]
    private CharacterController controller;
    private float speedMove = 7f;
    private float speedRotate = 10f;
    [SerializeField]
    private bool tankRotate = false;
    [SerializeField]
    private bool tankForward = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void moveTank()
    {
        float vertical = Input.GetAxis("Vertical");

        if (tankForward == true)
        {
            Vector3 move = transform.forward * vertical;

            controller.Move(move * speedMove * Time.deltaTime);

            tankRotate = false;
        }
    }

    public void rotateTank()
    {
        if (tankRotate == true)
        {
            float horizontal = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up, horizontal * speedRotate * Time.deltaTime);

            tankForward = false;
        }
    }

    public void CheckForward()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            tankRotate = true;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            tankForward = true;
        }
        else
        {
            tankRotate = false;
            tankForward = false;
        }

    }
}
