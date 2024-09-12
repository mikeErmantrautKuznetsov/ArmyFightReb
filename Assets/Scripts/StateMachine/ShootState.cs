using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State
{
    public void EnterShoot(State state)
    {
        state.Enter();
        Debug.Log("I SHOOT!!!");
    }

    public void ExitShoot(State state)
    {
        state.Exit();
        Debug.Log("I DON'T SHOOT!!!");
    }

    public void UpdateShoot(State state)
    {
        state.Update();
        Debug.Log("I SHOOT");
    }
}
