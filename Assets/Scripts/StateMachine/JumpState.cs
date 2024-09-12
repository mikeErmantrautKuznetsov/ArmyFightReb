using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public void EnterJump(State state)
    {
        state.Enter();
        Debug.Log("I Jump!!!");
    }

    public void ExitJump(State state)
    {
        state.Exit();
        Debug.Log("I DON Jump!!!");
    }
}
