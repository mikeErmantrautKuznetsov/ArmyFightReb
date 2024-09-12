using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerMove : MonoBehaviour
{
    private ITankMove tankMove;


    void Start()
    {
        tankMove = GetComponent<ITankMove>();
    }


    void Update()
    {
        tankMove.moveTank();
        tankMove.rotateTank();
        tankMove.CheckForward();
    }
}
