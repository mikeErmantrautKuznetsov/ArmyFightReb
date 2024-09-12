using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public void EnterIdle(State state)
    {
        state.Enter();
        Debug.Log("I Stay in this place");
    }

    public void ExitIdle(State state)
    {
        state.Exit();
        Debug.Log("I Leave");
    }
}
