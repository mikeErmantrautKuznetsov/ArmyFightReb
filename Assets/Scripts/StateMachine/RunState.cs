using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    public void EnterRun(State state)
    {
        state.Enter();
        Debug.Log("I RUN!!!");
    }

    public void ExitRun(State state)
    {
        state.Exit();
        Debug.Log("I DON RUN!!!");
    }
}
