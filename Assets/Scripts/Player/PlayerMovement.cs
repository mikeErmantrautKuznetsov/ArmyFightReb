using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PlayerMovement : MonoBehaviour
{
    private IControlleble controlleble;

    private void Start()
    {
        controlleble = GetComponent<IControlleble>();
    }

    void Update()
    {
        controlleble.MoveController();
        controlleble.JumpController();
        controlleble.GraviteController();
        controlleble.RotationPerson();
    }
}
